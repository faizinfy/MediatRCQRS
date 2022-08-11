using MediatRCQRS.Models;
using MediatRCQRS.Commands;
using MediatRCQRS.Repository;
using MediatR;
using MediatRCQRS.Data;

namespace MediatRCQRS.Handlers
{
  public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Todo>
  {
    private readonly ITodoRepository _todorepo;
    protected readonly ApplicationDbContext _db;

    public UpdateTodoHandler(ApplicationDbContext customDbContext, ITodoRepository todorepo)
    {
      _db = customDbContext;
      _todorepo = todorepo;
    }

    public async Task<Todo> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
      var todo = _db.Todos.Where(a => a.Id == command.Id).FirstOrDefault();
      if (todo == null)
        return default;
      else
      {
        todo.Title = command.Title;
        todo.Description = command.Description;
        return await _todorepo.UpdateAsync(todo);
      }
    }
  }
}
