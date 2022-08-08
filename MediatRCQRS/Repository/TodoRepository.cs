using MediatRCQRS.Data;
using MediatRCQRS.Models;

namespace MediatRCQRS.Repository
{
  public class TodoRepository : GenericRepository<Todo>, ITodoRepository
  {
    public TodoRepository(ApplicationDbContext _db) : base(_db)
    {
    }

  }
}
