using ECommerceTracker.Data;
using ECommerceTracker.Models;
using ECommerceTracker.Repositories;

namespace ECommerceTracker.UnitOfWork;

/// <summary>
/// Shares a single ApplicationDbContext across lazily-created repositories so
/// SaveChangesAsync commits changes from all of them in one transaction.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IRepository<Product>? _products;
    private IRepository<Order>? _orders;
    private IRepository<OrderItem>? _orderItems;

    private bool _disposed;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IRepository<Product> Products => _products ??= new Repository<Product>(_context);

    public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);

    public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}
