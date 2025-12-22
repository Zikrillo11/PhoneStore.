using PhoneStore.Domain.Entities;

namespace PhoneStore.BLL.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(long id);
    Task<Order> CreateAsync(long phoneId);
    Task<bool> DeleteAsync(long id);
}
