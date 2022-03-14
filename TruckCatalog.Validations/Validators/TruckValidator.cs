using FluentValidation;
using System;
using System.Collections.Generic;
using TruckCatalog.Models.Models;

namespace TruckCatalog.Validators.Validators
{
    public class TruckValidator : AbstractValidator<Truck>
    {
        public TruckValidator()
        {
            int currentYear = DateTime.Now.Year;
            int subsequentYear = DateTime.Now.Year + 1;

            List<string> models = new List<string>() { "FH", "FM" };
            List<int> modelYears = new List<int>() { currentYear, subsequentYear };

            RuleFor(truckModelName => truckModelName.ModelName)
                .Must(truckModelName => models.Contains(truckModelName))
                .WithMessage(string.Concat("Please, only use ", string.Join(" or ", models), " models."));

            RuleFor(truckManufactureYear => truckManufactureYear.ManufactureYear)
                .Must(truckManufactureYear => truckManufactureYear == currentYear)
                .WithMessage("Please, use the current year.");

            RuleFor(truckModelYear => truckModelYear.ModelYear)
                .Must(truckModelYear => modelYears.Contains(truckModelYear))
                .WithMessage(string.Concat("Please, only use ", string.Join(" or ", modelYears), " model years."));
        }
    }
}
