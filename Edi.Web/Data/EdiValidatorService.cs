using EdiNationAPI.Standard;
using EdiNationAPI.Standard.Http.Client;
using EdiService;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edi.Web.Data
{
    public class EdiValidatorService
    {
        public EdiValidatorService(ILogger<EdiValidatorService> logger)
        {
            Logger = logger;
        }

        public ILogger<EdiValidatorService> Logger { get; }

        public async Task<List<string>> ValidateWithEdiLibrary(string payload)
        {
            var results = new List<string>();

            var channel = GrpcChannel.ForAddress("https://localhost:5001"); // TODO: Move to appSettings.json file.
            var client = new Validator.ValidatorClient(channel);

            var request = new EdiValidationRequest() { Payload = payload };
            var reply = await client.ValidateEdiAsync(request);

            results.Add(reply.Message);
            return results;
        }

        public async Task<List<string>> ValidateWithEdiNation(string payload)
        {
            var results = new List<string>();

            string key = "760977dc931249c4b9d11a49f289adb2"; // TODO: Move to user secrets.
            EdiNationAPIClient client = new EdiNationAPIClient(key);
            var x12 = client.X12;

            var payloadByteArray = Encoding.UTF8.GetBytes(payload);
            var payloadMemorySteam = new MemoryStream(payloadByteArray);

            var psuedoFile = new FileStreamInfo(payloadMemorySteam);
            var x12Interchange = await x12.ReadAsync(psuedoFile, false, false, "utf-8", null);

            foreach (var item in x12Interchange[0].Result.Details)
            {
                results.Add(item.Message);
            }

            return results;
        }
    }
}
