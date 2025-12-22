namespace PhoneStore.Shared.DTOs.Phones;

public class PhoneForCreateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
