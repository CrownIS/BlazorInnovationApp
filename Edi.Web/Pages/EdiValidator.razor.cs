using Edi.Web.Data;
using Edi.Web.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Edi.Web.Pages
{
    public partial class EdiValidator
    {
        [Inject]
        public EdiValidatorService ValidatorService { get; set; }

        protected string Status = "Not submitted";
        protected EdiValidatorViewModel ViewModel = new EdiValidatorViewModel()
        { 
            ValidationEngine = ValidationEngineType.EdiLibrary
        };

        public void ValidationEngineSelection(ChangeEventArgs args)
        {
            if (args.Value.Equals("ediLibrary"))
            {
                ViewModel.ValidationEngine = ValidationEngineType.EdiLibrary;
            }
            else
            {
                ViewModel.ValidationEngine = ValidationEngineType.EdiNation;
            }
        }

        protected async Task FormSubmitted()
        {
            ViewModel.ValidationResults = await ValidatorService.Validate("Edi to validate.");

            Debug.WriteLine("Clicked ...");
            //Status = $"Form submitted: {reply}";
        }
    }
}
