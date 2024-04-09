using EventsWebApplication.Domain.Entities;

namespace EventsWebApplication.Application.Repositories;
public interface IUnitOfWork
{
    IRepository<Event> EventRepository { get; }
    IRepository<ApplicationUser> ApplicationUserRepository { get; }
    public Task CreateDatabaseAsync();
    public Task RemoveDatabaseAsync();
    public Task SaveAllAsync();
}
