using EventsWebApplication.Domain.Entities;
using System.Linq.Expressions;

namespace EventsWebApplication.Application.Repositories;
public interface IRepository<T> where T : IEntity
{
    //Search entity by Id
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default,
    params Expression<Func<T, object>>[]? includesProperties);

    //Get the list of entities
    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

    //Get the filtred list
    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default,
    params Expression<Func<T, object>>[]? includesProperties);

    //Add new entity
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    //Change entity
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    //Delete entity
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

    //Search for the first entity that satisfies the selection condition.
    //If the entity is not found, the default value will be returned
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken
    cancellationToken = default);
}
