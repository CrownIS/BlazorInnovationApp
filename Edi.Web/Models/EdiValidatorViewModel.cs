using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edi.Web.Models
{
    public class EdiValidatorViewModel
    {
        public EdiValidatorViewModel()
        {
            ValidationResults = new List<string>();
        }

        [Required(ErrorMessage ="You must supply some EDI text to validate.")]
        public string EdiRequest { get; set; }

        public ValidationEngineType ValidationEngine { get; set; }

        public List<string> ValidationResults { get; set; }
    }
}
