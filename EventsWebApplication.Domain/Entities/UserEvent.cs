namespace EventsWebApplication.Domain.Entities;
public class UserEvent
{
    public Guid ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public Guid EventId { get; set; }
    public Event? Event { get; set; }
    public DateTime RegistrationDate { get; set; }
}