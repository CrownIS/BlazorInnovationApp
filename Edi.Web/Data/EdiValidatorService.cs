using EdiService;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> Validate(string payload)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001"); // TODO: Move to appSettings.json file.
            var client = new Validator.ValidatorClient(channel);

            var request = new EdiValidationRequest() { Payload = payload };
            var reply = await client.ValidateEdiAsync(request);

            return reply.Message;
        }
    }
}
