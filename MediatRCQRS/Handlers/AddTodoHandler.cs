using MediatRCQRS.Models;
using MediatRCQRS.Commands;
using MediatRCQRS.Repository;
using MediatR;

namespace MediatRCQRS.Handlers
{
  public class AddTodoHandler : IRequestHandler<AddToDoCommand, Todo>
  {
    private readonly ITodoRepository _todorepo;
    public AddTodoHandler(ITodoRepository todorepo) => _todorepo = todorepo;

    public async Task<Todo> Handle(AddToDoCommand request, CancellationToken cancellationToken)
    {
      return await _todorepo.AddAsync(request.Todo);
    }

  }
}
