using AutoMapper;
using Customer.Application.Contracts.Persistence;
using Customer.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly ICustomerRepository _ctr;
        private readonly IMapper _mapper;
        private readonly ILogger<AddCustomerCommandHandler> _logger;

        public AddCustomerCommandHandler(ICustomerRepository ctr, IMapper mapper, ILogger<AddCustomerCommandHandler> logger)
        {
            _ctr = ctr;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerModel>(request);
            customer.CreatedDate = DateTimeOffset.Now.UtcDateTime;
            var newCustomer = await _ctr.AddAsync(customer);

            _logger.LogInformation($"customer with id {newCustomer.Id} has been added");

            return newCustomer.Id;
        }
    }
}
