namespace MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}