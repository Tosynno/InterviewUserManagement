using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class OnbardingRequestValidator : AbstractValidator<OnbardingRequest>
    {
        public OnbardingRequestValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
  .NotEmpty().WithMessage("Enter a valid value")
  .EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.Phone)
 .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Otp)
 .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.LastName)
 .NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.DateofBirth).NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Nationality).NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Enter a valid value");
            RuleFor(x => x.Photo).NotEmpty().WithMessage("Enter a valid value");
        }
    
    }
}
