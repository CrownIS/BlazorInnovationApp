using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            var output = new EdiValidationReply() 
            {
                Message = "It's all good!"
            };

            return Task.FromResult(output);
        }
    }
}
