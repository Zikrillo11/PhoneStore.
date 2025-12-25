using Microsoft.EntityFrameworkCore;
using PhoneStore.BLL.Interfaces;
using PhoneStore.DAL.Data;
using PhoneStore.Domain.Entities;

namespace PhoneStore.BLL.Services;

public class PhoneService : IPhoneService
{
    private readonly AppDbContext _context;

    public PhoneService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Phone>> GetAllAsync()
    {
        return await _context.Phones.ToListAsync();
    }

    public async Task<Phone?> GetByIdAsync(long id)
    {
        return await _context.Phones.FindAsync(id);
    }

    public async Task<Phone> CreateAsync(Phone phone)
    {
        var newPhone = new Phone
        {
            Name = phone.Name,
            Price = phone.Price,
            Description = phone.Description,
            ImageUrl = phone.ImageUrl
        };

        await _context.Phones.AddAsync(newPhone);
        await _context.SaveChangesAsync();

        return newPhone;
    }

    public async Task<bool> UpdateAsync(Phone phone)
    {
        var existing = await _context.Phones.FindAsync(phone.Id);
        if (existing == null)
            return false;

        existing.Name = phone.Name;
        existing.Price = phone.Price;
        existing.Description = phone.Description;
        existing.ImageUrl = phone.ImageUrl; 

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var phone = await _context.Phones.FindAsync(id);
        if (phone == null)
            return false;

        _context.Phones.Remove(phone);
        await _context.SaveChangesAsync();
        return true;
    }
}
