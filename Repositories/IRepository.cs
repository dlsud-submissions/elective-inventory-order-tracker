namespace ECommerceTracker.Repositories;

/// <summary>
/// Generic asynchronous CRUD abstraction over an EF Core entity set.
/// Persistence is deliberately excluded: SaveChangesAsync is centralized in the Unit of Work.
/// </summary>
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}
