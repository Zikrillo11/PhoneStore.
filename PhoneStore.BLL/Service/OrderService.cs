using Microsoft.EntityFrameworkCore;
using PhoneStore.BLL.Interfaces;
using PhoneStore.DAL.Data;
using PhoneStore.Domain.Entities;

namespace PhoneStore.BLL.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Phone)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(long id)
    {
        return await _context.Orders
            .Include(o => o.Phone)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> CreateAsync(long phoneId)
    {
        var phone = await _context.Phones.FindAsync(phoneId);
        if (phone == null)
            throw new Exception("Phone topilmadi");

        var order = new Order
        {
            PhoneId = phoneId,
            TotalPrice = phone.Price
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
