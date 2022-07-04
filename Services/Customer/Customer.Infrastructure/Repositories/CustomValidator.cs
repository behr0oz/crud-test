using Customer.Application.Contracts.Infrastructure;
using Customer.Application.Contracts.Persistence;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
    public class CustomValidator : ICustomValidator
    {
        private readonly ICustomerRepository _ctr;

        public CustomValidator(ICustomerRepository ctr)
        {
            _ctr = ctr;
        }

        public bool IsCustomerUnique(string firstname, string lastname, DateTime dateOfBirth, int? id)
        {
            if (id is null)
            {
                var customerExists = _ctr.FirstOrDefault(o => o.Firstname == firstname
                                             && o.Lastname == lastname
                                             && o.DateOfBirth == dateOfBirth).Result;
                if (customerExists != null)
                    return false;
            }
            else
            {
                var customerExists = _ctr.FirstOrDefault(o => o.Firstname == firstname
                                            && o.Lastname == lastname
                                            && o.DateOfBirth == dateOfBirth && o.Id != id.Value).Result;
                if (customerExists != null)
                    return false;
            }
            return true;
        }

        public bool IsEmailUnique(string email, int? id)
        {
            if (id is null)
            {
                var customerEmailExists = _ctr.FirstOrDefault(o => o.Email == email).Result;
                if (customerEmailExists != null)
                    return false;
            }
            else
            {
                var customerEmailExists = _ctr.FirstOrDefault(o => o.Email == email && o.Id != id.Value).Result;
                if (customerEmailExists != null)
                    return false;
            }
            return true;
        }

        public bool ValidatePhone(string phoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var phone = phoneUtil.Parse(phoneNumber, null);
                if (phone != null)
                    return true;
            }
            catch (NumberParseException ex)
            {

            }
            return false;
        }
    }
}
