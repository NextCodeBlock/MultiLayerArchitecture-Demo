using Microsoft.EntityFrameworkCore;
using MultiLayerArchitectureDemo.DataAccessLayer.Context;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;
using System.Threading;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Abstracts;

public class CustomerRepository: ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Customers.ToListAsync(cancellationToken);
    }

    public async Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var findData = await _context.Customers.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        return findData ?? new Customer();
    }

    public async Task<Customer> AddAsync(Customer entity, CancellationToken cancellationToken)
    {
        await _context.Customers.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(Customer entity, CancellationToken cancellationToken)
    {
        Customer? exist = _context.Customers.Find(entity.Id);

        if (exist == null)
            throw new Exception("The entity cannot found.");
        
        _context.Entry(exist).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Customer entity, CancellationToken cancellationToken)
    {
        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}