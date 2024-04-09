using EventsWebApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApplication.Infrastructure.Data;
public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
        .HasMany(e => e.Events)
        .WithMany(e => e.Participants)
        .UsingEntity<UserEvent>(
            l => l.HasOne<Event>(e => e.Event).WithMany(e => e.UserEvents),
            r => r.HasOne<ApplicationUser>(e => e.ApplicationUser).WithMany(e => e.UserEvents));

        var events = new List<Event>
        {
            new() {
                Id = Guid.NewGuid(),
                Name = "Event 1",
                Description = "Description of Event 1",
                DateTime = DateTime.Now.AddDays(1),
                Location = "Location 1",
                Category = "Category 1",
                MaxParticipants = 100,
                Image = "event1.jpg"
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Event 2",
                Description = "Description of Event 2",
                DateTime = DateTime.Now.AddDays(2),
                Location = "Location 2",
                Category = "Category 2",
                MaxParticipants = 50,
                Image = "event2.jpg"
            },
        };

        builder.Entity<Event>().HasData(events);
        base.OnModelCreating(builder);
    }
    public DbSet<Event> Events { get; set; }
}
