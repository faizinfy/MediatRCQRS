using MediatRCQRS.Models;
using MediatRCQRS.Queries;
using MediatRCQRS.Repository;
using MediatR;

namespace MediatRCQRS.Handlers
{
  public class GetAllToDoQueryHandler : IRequestHandler<GetAllTodoQuery, List<Todo>>
  {
    private readonly ITodoRepository _todorepo;
    public GetAllToDoQueryHandler(ITodoRepository todrepo) => _todorepo = todrepo;
    public async Task<List<Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
    {
      return _todorepo.GetAll().ToList();
    }
  }
}
