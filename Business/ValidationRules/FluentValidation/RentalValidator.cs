﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r=>r.CarID).NotEmpty();
            RuleFor(r => r.CustomerID).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty().GreaterThan(DateTime.Now).WithMessage("Kiralama tarihi geçmiş zaman olamaz");
            RuleFor(r => r.ReturnDate).NotEmpty().GreaterThanOrEqualTo(r=>r.ReturnDate).WithMessage("Teslim tarihi kiralama tarihinden önce olamaz") ;
        }
    }
}
