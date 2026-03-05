using FluentValidation;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Lesson9_Online_Store_Domain.Entities.Concretes;

namespace Lesson9_Online_Store_DataAccess.Validations.ProductValidation;

public class ProductValidator : AbstractValidator<Product>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductValidator(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product adı boş ola bilməz")
            .MinimumLength(2).WithMessage("Product adı minimum 2 simvol olmalıdır");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Qiymət 0-dan böyük olmalıdır");

        RuleFor(x => x.ProductCount)
            .GreaterThanOrEqualTo(0).WithMessage("Say 0-dan kiçik ola bilməz");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category seçilməlidir");
    }
}

