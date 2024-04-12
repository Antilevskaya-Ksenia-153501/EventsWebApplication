namespace EventsWebApplication.Domain.Entities;
public class Location : IEntity
{
    public Guid Id { get; set; }
    public string Name {  get; set; }
    List<Event> Events { get; set; }
}
