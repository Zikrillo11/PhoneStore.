namespace PhoneStore.Shared.DTOs.Orders;

public class OrderForResultDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public List<string> PhoneNames { get; set; } = new List<string>();
}
