using Lesson9_Online_Store_Domain.Entities.Abstracts;

namespace Lesson9_Online_Store_Domain.Entities.Concretes;

public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int ProductCount { get; set; }

    public virtual Category Category { get; set; } = null!;
}

