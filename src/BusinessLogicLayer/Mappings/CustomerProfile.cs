using AutoMapper;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Commands.AddUpdate;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetAll;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetById;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;

namespace MultiLayerArchitectureDemo.BusinessLogicLayer.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<AddUpdateCustomerCommand, Customer>().ReverseMap();
        CreateMap<GetCustomerByIdResponse, Customer>().ReverseMap();
        CreateMap<GetAllCustomersResponse, Customer>().ReverseMap();
    }
}