using Microsoft.EntityFrameworkCore;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;
using MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;
using System.Reflection;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("MultiLayerDemo");
    }
}