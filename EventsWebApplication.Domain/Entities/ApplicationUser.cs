using Microsoft.AspNetCore.Identity;

namespace EventsWebApplication.Domain.Entities;
public class ApplicationUser : IdentityUser, IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Event> Events { get; set; } = new();
    public List<UserEvent> UserEvents { get; set; } = new();
}
