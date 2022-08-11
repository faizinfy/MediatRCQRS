using MediatRCQRS.Models;
using MediatRCQRS.Commands;
using MediatRCQRS.Repository;
using MediatR;
using MediatRCQRS.Data;

namespace MediatRCQRS.Handlers
{
  public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, int>
  {
    private readonly ITodoRepository _todorepo;
    protected readonly ApplicationDbContext _db;

    public DeleteTodoHandler(ApplicationDbContext customDbContext, ITodoRepository todorepo)
    {
      _db = customDbContext;
      _todorepo = todorepo;
    }

    public async Task<int> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
      //var currenttodo = _db.Todos.Where(a => a.Id == command.Id).FirstOrDefault();
      //_db.Todos.Remove(currenttodo);
      //await _db.SaveChangesAsync();
      //return currenttodo.Id;
      return await _todorepo.DeleteAsync(command.Id);
    }

  }
}
