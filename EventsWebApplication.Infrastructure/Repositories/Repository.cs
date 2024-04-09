using EventsWebApplication.Application.Repositories;
using EventsWebApplication.Domain.Entities;
using EventsWebApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventsWebApplication.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    //Search entity by Id
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default,
    params Expression<Func<T, object>>[]? includesProperties)
    {

        IQueryable<T>? query = _entities.AsQueryable();
        if (includesProperties != null && includesProperties.Any())
        {
            foreach (Expression<Func<T, object>>? included in includesProperties)
            {
                query = query.Include(included);
            }
        }
        return await _entities.FirstOrDefaultAsync(el => el.Id == id, cancellationToken);
    }

    //Get the list of entities
    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.AsQueryable().ToListAsync(cancellationToken);
    }

    //Get the filtred list
    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default,
    params Expression<Func<T, object>>[]? includesProperties)
    {
        IQueryable<T>? query = _entities.AsQueryable();
        if (includesProperties != null && includesProperties.Any())
        {
            foreach (Expression<Func<T, object>>? included in includesProperties)
            {
                query = query.Include(included);
            }
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync(cancellationToken);
    }

    //Add new entity
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
    }

    //Change entity
    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        _context.Entry(entity).State = EntityState.Detached;
        return Task.CompletedTask;
    }

    //Delete entity
    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _entities.Remove(entity);
    }

    //Search for the first entity that satisfies the selection condition.
    //If the entity is not found, the default value will be returned
    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
    cancellationToken = default)
    {
        return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
    }
}
