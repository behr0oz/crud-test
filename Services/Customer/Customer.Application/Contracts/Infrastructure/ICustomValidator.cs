using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Contracts.Infrastructure
{
    public interface ICustomValidator
    {
        bool ValidatePhone(string phoneNumber);

        bool IsEmailUnique(string email, int? id);

        bool IsCustomerUnique(string firstname, string lastname, DateTime dateOfBirth, int? id);

    }
}
