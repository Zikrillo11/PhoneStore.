using PhoneStore.Domain.Entities;

namespace PhoneStore.BLL.Interfaces;

public interface IPhoneService
{
    Task<List<Phone>> GetAllAsync();
    Task<Phone?> GetByIdAsync(long id);
    Task<Phone> CreateAsync(Phone phone);
    Task<bool> UpdateAsync(Phone phone);
    Task<bool> DeleteAsync(long id);
}
