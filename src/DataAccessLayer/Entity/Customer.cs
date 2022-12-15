using MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

namespace MultiLayerArchitectureDemo.DataAccessLayer.Entity;

public class Customer: Entity<Guid>
{
    public string CustomerName { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }
}