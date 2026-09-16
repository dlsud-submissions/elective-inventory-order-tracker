using ECommerceTracker.Models;
using ECommerceTracker.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTracker.Controllers;

public class OrdersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Orders
    public async Task<IActionResult> Index()
    {
        return View(await _unitOfWork.Orders.GetAllAsync());
    }

    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var order = await _unitOfWork.Orders.GetByIdAsync(id.Value);
        if (order is null)
        {
            return NotFound();
        }

        return View(order);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Orders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,CustomerEmail,OrderDate,TotalAmount")] Order order)
    {
        if (ModelState.IsValid)
        {
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(order);
    }

    // GET: Orders/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var order = await _unitOfWork.Orders.GetByIdAsync(id.Value);
        if (order is null)
        {
            return NotFound();
        }

        return View(order);
    }

    // POST: Orders/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerEmail,OrderDate,TotalAmount")] Order order)
    {
        if (id != order.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(order);
    }

    // GET: Orders/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var order = await _unitOfWork.Orders.GetByIdAsync(id.Value);
        if (order is null)
        {
            return NotFound();
        }

        return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order is not null)
        {
            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
