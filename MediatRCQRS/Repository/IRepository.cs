namespace MediatRCQRS.Repository
{
  public interface IRepository<TEntity> where TEntity : class, new()
  {
    IEnumerable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(int id);
  }
}
