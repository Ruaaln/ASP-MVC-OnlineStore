using Lesson9_Online_Store_DataAccess.Contexts;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;

namespace Lesson9_Online_Store_DataAccess.Repositories.Concrete;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
