using MediatRCQRS.Models;
using MediatR;

namespace MediatRCQRS.Commands
{
  public class DeleteTodoCommand : IRequest<int>
  {
    public int Id { get; set; }
  }
}
