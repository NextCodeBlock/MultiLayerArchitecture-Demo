namespace MultiLayerArchitectureDemo.DataAccessLayer.SeedWork;

public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}

public interface IEntity
{

}