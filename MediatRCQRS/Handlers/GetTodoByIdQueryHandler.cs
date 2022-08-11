using MediatRCQRS.Models;
using MediatRCQRS.Queries;
using MediatRCQRS.Repository;
using MediatR;

namespace MediatRCQRS.Handlers
{
  public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, Todo>
  {
    private readonly ITodoRepository _todorepo;
    public GetTodoByIdQueryHandler(ITodoRepository todrepo) => _todorepo = todrepo;
    public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
      return await _todorepo.GetByIdAsync(request.Id);
    }
  }
}
