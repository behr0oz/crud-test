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

namespace Customer.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _ctr;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository ctr, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _ctr = ctr;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _ctr.GetByIdAsync(request.Id);
            if (customer is null)
            {
                throw new NotFoundException(nameof(CustomerModel), request.Id);
            }
            await _ctr.DeleteAsync(customer);

            _logger.LogInformation($"Customer with Id {request.Id} successfuly deleted.");

            return Unit.Value;
        }
    }
}
