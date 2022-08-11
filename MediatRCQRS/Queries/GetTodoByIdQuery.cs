using MediatR;
using MediatRCQRS.Models;

namespace MediatRCQRS.Queries
{
  public class GetTodoByIdQuery : IRequest<Todo>
  {
    public int Id { get; }
    public GetTodoByIdQuery(int id)
    {
      Id = id;
    }
  }
}
