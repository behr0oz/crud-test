using Customer.Application.Contracts.Persistence;
using Customer.Domain.Entities;
using Customer.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext dbContext) : base(dbContext)
        {

        }


    }
}
