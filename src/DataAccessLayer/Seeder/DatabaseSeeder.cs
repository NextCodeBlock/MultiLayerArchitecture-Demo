using Microsoft.Extensions.Logging;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;
using MultiLayerArchitectureDemo.DataAccessLayer.Context;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Seeder;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly ILogger<DatabaseSeeder> _logger;
    private readonly ApplicationDbContext _db;

    public DatabaseSeeder(ApplicationDbContext db, ILogger<DatabaseSeeder> logger)
    {
        _db = db;
        _logger = logger;
    }

    public void Initialize()
    {
        AddCustomers();
        _db.SaveChanges();
    }

    private void AddCustomers()
    {
        Task.Run(() =>
        {
            if (!_db.Customers.Any())
            {
                IEnumerable<Customer> customers = new List<Customer>()
                {
                    new Customer
                    {
                        CustomerName = "Amin Ziagham",
                        Email = "amin.ziagham@gmail.com",
                        Website = "https://nextcodeblock.com",
                        IsActive = true
                    }
                };
                _db.Customers.AddRange(customers);
            }
        }).GetAwaiter().GetResult();
    }
}