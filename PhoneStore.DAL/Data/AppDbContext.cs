using Microsoft.EntityFrameworkCore;
using PhoneStore.Domain.Entities;

namespace PhoneStore.DAL.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Phone> Phones { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
}
