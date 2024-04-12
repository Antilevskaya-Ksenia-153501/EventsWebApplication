namespace EventsWebApplication.Domain.Entities;
public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Event> Events { get; set; }
}
