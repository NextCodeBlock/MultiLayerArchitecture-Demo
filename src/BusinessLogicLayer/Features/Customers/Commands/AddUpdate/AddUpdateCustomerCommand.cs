using AutoMapper;
using MediatR;
using MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;
using MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Commands.AddUpdate;

public class AddUpdateCustomerCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? CustomerName { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }
}

internal class AddUpdateCustomerCommandHandler : IRequestHandler<AddUpdateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public AddUpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddUpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (command.Id == Guid.Empty)
        {
            var customer = _mapper.Map<Customer>(command);
            await _customerRepository.AddAsync(customer, cancellationToken);
            return customer.Id;
        }
        else
        {
            var customer = await _customerRepository.GetByIdAsync(command.Id, cancellationToken);
            customer.CustomerName = command.CustomerName ?? customer.CustomerName;
            customer.Email = command.Email ?? customer.Email;
            customer.Website = command.Website ?? customer.Website;
            customer.Phone = command.Phone ?? customer.Phone;
            customer.Fax = command.Fax ?? customer.Fax;
            customer.Address = command.Address ?? customer.Address;
            customer.IsActive = command.IsActive;
            await _customerRepository.UpdateAsync(customer, cancellationToken);
            return customer.Id;
        }
    }
}