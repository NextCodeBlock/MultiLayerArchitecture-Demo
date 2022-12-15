using AutoMapper;
using MediatR;
using MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetById;

public class GetByIdCustomerQuery : IRequest<GetCustomerByIdResponse>
{
    public Guid CustomerId { get; set; }
}

internal class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetCustomerByIdResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GetCustomerByIdResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        var mappedCustomer = _mapper.Map<GetCustomerByIdResponse>(customer);
        return mappedCustomer;
    }
}