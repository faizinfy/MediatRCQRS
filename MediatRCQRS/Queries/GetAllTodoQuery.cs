using MediatRCQRS.Models;
using MediatR;

namespace MediatRCQRS.Queries
{
  public class GetAllTodoQuery : IRequest<List<Todo>>
  {
  }
}
