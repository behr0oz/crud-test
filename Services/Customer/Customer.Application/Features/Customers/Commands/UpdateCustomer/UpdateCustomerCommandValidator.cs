using Customer.Application.Contracts.Infrastructure;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(ICustomValidator customValidator)
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
                .Must((updateCustomerCommand, email) => customValidator.IsEmailUnique(email, updateCustomerCommand.Id)).WithMessage("Email already exists");

            RuleFor(p => p.Firstname)
                .Must((updateCustomerCommand, firstname) =>
                    customValidator.IsCustomerUnique(updateCustomerCommand.Firstname, updateCustomerCommand.Lastname,
                    updateCustomerCommand.DateOfBirth, updateCustomerCommand.Id))
                .WithMessage("Customer already exists");

        }
    }
}
