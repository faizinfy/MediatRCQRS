using MediatRCQRS.Models;
using MediatR;

namespace MediatRCQRS.Commands
{
  public class UpdateTodoCommand : IRequest<Todo>
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

  }
}
