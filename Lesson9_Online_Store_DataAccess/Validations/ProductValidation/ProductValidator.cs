using FluentValidation;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Lesson9_Online_Store_Domain.Entities.Concretes;

namespace Lesson9_Online_Store_DataAccess.Validations.ProductValidation;

public class ProductValidator : AbstractValidator<Product>
{
    private readonly IProductRepository _productRepository;

    public ProductValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product adı boş ola bilməz");

        RuleFor(x => x.Id)
            .MustAsync(BeUniqueProduct)
            .WithMessage("Bu product artıq mövcuddur");
    }

    private async Task<bool> BeUniqueProduct(int id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product == null;
    }
}

