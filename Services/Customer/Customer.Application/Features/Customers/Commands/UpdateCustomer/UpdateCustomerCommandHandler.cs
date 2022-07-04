using AutoMapper;
using Customer.Application.Contracts.Persistence;
using Customer.Application.Exceptions;
using Customer.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _ctr;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository ctr, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _ctr = ctr;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await _ctr.GetByIdAsync(request.Id);
            if (customer is null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.Id);
            }

            _mapper.Map(request, customer, typeof(UpdateCustomerCommand), typeof(CustomerModel));

            customer.LastModifiedDate = DateTimeOffset.Now.UtcDateTime;
            await _ctr.UpdateAsync(customer);

            _logger.LogInformation($"Customer with Id {request.Id} successfuly updated.");

            return Unit.Value;
        }
    }
}
