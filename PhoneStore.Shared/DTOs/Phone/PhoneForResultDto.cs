namespace PhoneStore.Shared.DTOs.Phones;

public class PhoneForResultDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; } = null!;
}
