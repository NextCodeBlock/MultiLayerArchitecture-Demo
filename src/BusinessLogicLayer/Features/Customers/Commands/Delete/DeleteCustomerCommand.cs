using AutoMapper;
using MediatR;
using MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;
using MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Commands.AddUpdate;

public class DeleteCustomerCommand : IRequest<Guid>
{
    public Guid CustomerId { get; set; }
}

internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        await _customerRepository.DeleteAsync(customer, cancellationToken);
        return customer.Id;
    }
}