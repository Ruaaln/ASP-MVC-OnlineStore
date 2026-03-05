using FluentValidation;
using Lesson9_Online_Store_Services.Results;
using Lesson9_Online_Store_Services.Abstractions;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;

namespace Lesson9_Online_Store_Services.Concretes;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IValidator<Product> _productValidator;

    public ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IValidator<Product> productValidator)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _productValidator = productValidator;
    }

    public async Task<ServiceResult<List<Product>>> GetAllAsync()
    {
        var data = await _productRepository.GetAllAsync();
        return ServiceResult<List<Product>>.Success(data);
    }

    public async Task<ServiceResult<List<Category>>> GetCategoriesAsync()
    {
        var data = await _categoryRepository.GetAllAsync();
        return ServiceResult<List<Category>>.Success(data);
    }

    public async Task<ServiceResult<bool>> CreateAsync(Product product)
    {
        var validation = await _productValidator.ValidateAsync(product);
        if (!validation.IsValid)
            return ServiceResult<bool>.Fail(validation.Errors.Select(e => e.ErrorMessage));

        var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
        if (category == null)
            return ServiceResult<bool>.Fail(new[] { "Seçilən category mövcud deyil" });

        var all = await _productRepository.GetAllAsync();
        var isDuplicate = all.Any(p =>
            p.Id != product.Id &&
            p.CategoryId == product.CategoryId &&
            (p.Name ?? "").Trim().ToLower() == (product.Name ?? "").Trim().ToLower());

        if (isDuplicate)
            return ServiceResult<bool>.Fail(new[] { "Bu category daxilində eyni adlı product artıq var" });

        await _productRepository.AddAsync(product);
        return ServiceResult<bool>.Success(true);
    }
}