namespace pokemon.api.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll(TEntity entity);
    }
}
