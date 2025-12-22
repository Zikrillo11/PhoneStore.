namespace PhoneStore.Domain.Entities;

public class Order
{
    public long Id { get; set; }

    public long PhoneId { get; set; }

    public Phone Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);

    public double TotalPrice { get; set; }

    public bool IsActive { get; set; } = true;
}
