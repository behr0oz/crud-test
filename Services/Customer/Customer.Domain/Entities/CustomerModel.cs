using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities
{
    public class CustomerModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Firstname { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Lastname { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string BankAccountNumber { get; set; }
    }
}
