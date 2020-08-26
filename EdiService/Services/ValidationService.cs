using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace EdiService.Services
{
    public class ValidationService : Edi.EdiBase
    {
        private readonly ILogger<ValidationService> logger;

        public ValidationService(ILogger<ValidationService> logger)
        {
            this.logger = logger;
        }

        public override Task<ValidationReply> Validate(ValidationRequest request, ServerCallContext context)
        {
            return base.Validate(request, context);
        }
    }
}
