using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.CustomerName).HasMaxLength(256).IsRequired();
    }
}