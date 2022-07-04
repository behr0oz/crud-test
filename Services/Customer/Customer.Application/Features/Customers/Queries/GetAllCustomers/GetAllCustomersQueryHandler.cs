using AutoMapper;
using Customer.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<GetAllCustomersVM>>
    {
        private readonly ICustomerRepository _ctr;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository ctr, IMapper mapper)
        {
            _ctr = ctr;
            _mapper = mapper;
        }

        public async Task<List<GetAllCustomersVM>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _ctr.GetAllAsync();
            return _mapper.Map<List<GetAllCustomersVM>>(customers);
        }
    }
}
