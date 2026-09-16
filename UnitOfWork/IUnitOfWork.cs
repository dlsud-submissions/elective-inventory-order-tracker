using ECommerceTracker.Models;
using ECommerceTracker.Repositories;

namespace ECommerceTracker.UnitOfWork;

/// <summary>
/// Exposes one repository per aggregate and a single SaveChangesAsync so that
/// changes across repositories commit together in one transaction.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }

    IRepository<Order> Orders { get; }

    IRepository<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync();
}
