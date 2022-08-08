namespace MediatRCQRS.Models
{
  public class Todo : IEntity
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

  }
}
