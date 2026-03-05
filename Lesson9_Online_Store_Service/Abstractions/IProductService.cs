using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_Services.Results;

namespace Lesson9_Online_Store_Services.Abstractions;


public interface IProductService
{
    Task<ServiceResult<List<Product>>> GetAllAsync();
    Task<ServiceResult<List<Category>>> GetCategoriesAsync();
    Task<ServiceResult<bool>> CreateAsync(Product product);
}