namespace EventsWebApplication.Domain.Entities;
public class Event : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public int MaxParticipants { get; set; }
    public List<ApplicationUser> Participants { get; set; } = new();
    public string? Image { get; set; }
    public List<UserEvent> UserEvents { get; set; } = new();
}
