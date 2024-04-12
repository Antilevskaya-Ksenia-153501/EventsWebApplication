using EventsWebApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

        builder.Entity<Event>()
        .HasOne(e => e.Category)
        .WithMany()
        .HasForeignKey(e => e.CategoryId);

        builder.Entity<Event>()
        .HasOne(e => e.Location)
        .WithMany()
        .HasForeignKey(e => e.LocationId);

        var categories = new List<Category>
        {
            new Category { Id = Guid.NewGuid(), Name = "Category 1" },
            new Category { Id = Guid.NewGuid(), Name = "Category 2" }
        };

        var locations = new List<Location>
        {
            new Location { Id = Guid.NewGuid(), Name = "Location 1" },
            new Location { Id = Guid.NewGuid(), Name = "Location 2" }
        };

        var events = new List<Event>
        {
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event 1",
                Description = "Description of Event 1",
                DateTime = DateTime.Now.AddDays(1),
                LocationId = locations[0].Id,
                CategoryId = categories[0].Id,
                MaxParticipants = 100,
                Image = "event1.jpg"
            },
            new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event 2",
                Description = "Description of Event 2",
                DateTime = DateTime.Now.AddDays(2),
                LocationId = locations[1].Id,
                CategoryId = categories[1].Id,
                MaxParticipants = 50,
                Image = "event2.jpg"
            }
        };

        builder.Entity<Category>().HasData(categories);
        builder.Entity<Location>().HasData(locations);
        builder.Entity<Event>().HasData(events);
        base.OnModelCreating(builder);
    }
    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Category { get; set;  }
    public DbSet<Location> Location { get; set; }
}
