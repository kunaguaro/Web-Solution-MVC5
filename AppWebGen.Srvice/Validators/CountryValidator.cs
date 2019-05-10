using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppGen.Model.Entities;

namespace AppWebGen.Service.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("Is necessary to inform the Name.")
               .MaximumLength(30).WithMessage("Name must be no longer than 100 characters.")
               .NotNull().WithMessage("Is necessary to inform the Name.");

            //RuleFor(c => c.Population)
            //    .NotEmpty().WithMessage("Is necessary to inform the Population.")
            //    .Must(ValidatePopulation).WithMessage("Population must be greater than 0");

            //RuleFor(c => c.Area)
            //  .NotEmpty().WithMessage("Is necessary to inform the Area.")
            //  .Must(ValidateArea).WithMessage("Area must be greater than 0");


        }

        //private bool ValidatePopulation(int population)
        //{

        //    if (population < 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private bool ValidateArea(decimal area)
        //{

        //    if (area < 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    }
}
