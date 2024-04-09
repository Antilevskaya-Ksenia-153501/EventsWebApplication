using EventsWebApplication.Application.Repositories;
using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Infrastructure.Data;

namespace EventsWebApplication.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IRepository<Event> _eventRepository;
    private readonly IRepository<ApplicationUser> _userRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _eventRepository = new Repository<Event>(context);
        _userRepository = new Repository<ApplicationUser>(context);
    }
    IRepository<Event> IUnitOfWork.EventRepository => _eventRepository;
    IRepository<ApplicationUser> IUnitOfWork.ApplicationUserRepository => _userRepository;

    public async Task CreateDatabaseAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task RemoveDatabaseAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    public async Task SaveAllAsync()
    {
        await _context.SaveChangesAsync();
    }
}
