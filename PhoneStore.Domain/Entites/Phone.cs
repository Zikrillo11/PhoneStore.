using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Entities;

[Table("phones")]
public class Phone
{
    [Key, Column("id")]
    public long Id { get; set; }

    [Column("name"), Required]
    public string Name { get; set; }

    [Column("price"), Required]
    public double Price { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; } // rasm URL saqlash uchun
}
