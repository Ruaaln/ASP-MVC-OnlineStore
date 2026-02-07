using Lesson9_Online_Store_Domain.Entities.Abstracts;

namespace Lesson9_Online_Store_Domain.Entities.Concretes;

public class Category : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }
}
