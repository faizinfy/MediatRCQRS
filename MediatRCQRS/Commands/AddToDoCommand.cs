using MediatRCQRS.Models;
using MediatR;

namespace MediatRCQRS.Commands
{
  public class AddToDoCommand : IRequest<Todo>
  {
    public Todo Todo { get; set; }
  }
}
