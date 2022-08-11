using MediatRCQRS.Models;
using MediatRCQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace MediatRCQRS.Repository
{
  public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity,new ()
  {
    protected readonly ApplicationDbContext _db;

    public GenericRepository(ApplicationDbContext customDbContext) => _db = customDbContext;

    public IEnumerable<TEntity> GetAll() => _db.Set<TEntity>();

    public async Task<TEntity> GetByIdAsync(int id)
    {
      return await _db.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
      ArgumentNullException.ThrowIfNull(entity);

      await _db.AddAsync(entity);
      await _db.SaveChangesAsync();

      return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
      ArgumentNullException.ThrowIfNull(entity);

      _db.Update(entity);
      await _db.SaveChangesAsync();

      return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
      ArgumentNullException.ThrowIfNull(id);
      var itemToRemove = await _db.Set<TEntity>().FindAsync(id);
      _db.Remove(itemToRemove);
      await _db.SaveChangesAsync();
      return id;
    }

  }
}
