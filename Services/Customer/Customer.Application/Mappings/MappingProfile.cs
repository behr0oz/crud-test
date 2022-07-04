using AutoMapper;
using Customer.Application.Features.Customers.Commands.AddCustomer;
using Customer.Application.Features.Customers.Commands.UpdateCustomer;
using Customer.Application.Features.Customers.Queries.GetAllCustomers;
using Customer.Application.Features.Customers.Queries.GetCustomerById;
using Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, GetAllCustomersVM>().ReverseMap();
            CreateMap<CustomerModel, GetCustomerByIdVM>().ReverseMap();
            CreateMap<CustomerModel, AddCustomerCommand>().ReverseMap();
            CreateMap<CustomerModel, UpdateCustomerCommand>().ReverseMap();
        }
    }
}
