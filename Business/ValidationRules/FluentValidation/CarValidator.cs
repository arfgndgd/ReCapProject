using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c => c.BrandID).NotEmpty();
            RuleFor(c => c.ColorID).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(100);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(200).When(c=>c.BrandID==2);
        }
    }
}
