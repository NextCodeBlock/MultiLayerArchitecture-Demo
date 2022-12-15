using MultiLayerArchitectureDemo.DataAccessLayer.Entity;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Customer> AddAsync(Customer entity, CancellationToken cancellationToken);
    Task UpdateAsync(Customer entity, CancellationToken cancellationToken);
    Task DeleteAsync(Customer entity, CancellationToken cancellationToken);
}