namespace EventsWebApplication.Domain.Entities;
public class Event : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public int MaxParticipants { get; set; }
    public List<ApplicationUser> Participants { get; set; } = new();
    public string? Image { get; set; }
    public List<UserEvent> UserEvents { get; set; } = new();
}
