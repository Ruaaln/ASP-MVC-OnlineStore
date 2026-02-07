using Lesson9_Online_Store_DataAccess.Contexts;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Lesson9_Online_Store_Domain.Entities.Concretes;

namespace Lesson9_Online_Store_DataAccess.Repositories.Concrete;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
