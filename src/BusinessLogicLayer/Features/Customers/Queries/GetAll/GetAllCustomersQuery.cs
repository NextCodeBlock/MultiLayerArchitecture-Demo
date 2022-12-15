using AutoMapper;
using MediatR;
using MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetAll;

public class GetAllCustomersQuery : IRequest<IEnumerable<GetAllCustomersResponse>>
{

}

internal class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<GetAllCustomersResponse>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllCustomersResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customerData = await _customerRepository.GetAllAsync(cancellationToken);
        var mappedCustomers = _mapper.Map<List<GetAllCustomersResponse>>(customerData);
        return mappedCustomers;
    }
}