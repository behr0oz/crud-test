using AutoMapper;
using Customer.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdVM>
    {
        private readonly ICustomerRepository _ctr;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository ctr, IMapper mapper)
        {
            _ctr = ctr;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdVM> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _ctr.GetByIdAsync(request.Id);
            return _mapper.Map<GetCustomerByIdVM>(customer);
        }
    }
}
