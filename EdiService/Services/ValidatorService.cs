using Grpc.Core;
using ImportExport5010_270;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EdiService.Services
{
    public class ValidatorService : Validator.ValidatorBase
    {
        public ValidatorService(ILogger<ValidatorService> logger)
        {
            Logger = logger;
        }

        public ILogger<ValidatorService> Logger { get; }

        public override Task<EdiValidationReply> ValidateEdi(EdiValidationRequest request, ServerCallContext context)
        {
            EligibilityInquiryReader inquiryReader;
            EligibilityInquiry inquiry;
            string validationResult = "Edi is valid";

            try
            {
                using (var sr = new StringReader(request.Payload))
                {
                    inquiryReader = new EligibilityInquiryReader(sr, EDIX12Core.UnexpectedSegmentHandling.ThrowException);
                    inquiry = inquiryReader.ReadItem();
                }
            }
            catch (Exception ex)
            {
                validationResult = ex.Message;
            }

            var output = new EdiValidationReply()
            {
                Message = validationResult
            };

            return Task.FromResult(output);
        }
    }
}
