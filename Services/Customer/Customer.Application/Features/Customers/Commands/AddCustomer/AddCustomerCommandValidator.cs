using Customer.Application.Contracts.Infrastructure;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator(ICustomValidator customValidator)
        {
            RuleFor(p => p.Firstname)
                .NotEmpty()
                .NotNull().WithMessage("Firstname is required.");

            RuleFor(p => p.Lastname)
                .NotEmpty()
                .NotNull().WithMessage("Lastname is required.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .NotNull()
                .Must(phoneNumber => customValidator.ValidatePhone(phoneNumber)).WithMessage("Phone number is invalid");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid")
                .Must((addCustomerCommand, email) => customValidator.IsEmailUnique(email, null)).WithMessage("Email already exists");

            RuleFor(p => p.Firstname)
                .Must((addCustomerCommand, firstname) =>
                        customValidator.IsCustomerUnique(addCustomerCommand.Firstname, addCustomerCommand.Lastname, addCustomerCommand.DateOfBirth, null))
                    .WithMessage("Customer already exists");

        }
    }
}
