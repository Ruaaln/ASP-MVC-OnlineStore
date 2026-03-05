using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Lesson9_Online_Store_DataAccess.Repositories.Concrete;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Lesson9_Online_Store_MVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var result = await _productService.GetAllAsync();
        return View(result.Data ?? new List<Product>());
    }

    [HttpGet]
    public async Task<IActionResult> AddProduct()
    {
        var cats = await _productService.GetCategoriesAsync();
        ViewBag.Categories = cats.Data ?? new List<Category>();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        var result = await _productService.CreateAsync(product);

        if (!result.IsSuccess)
        {
            foreach (var err in result.Errors)
                ModelState.AddModelError(string.Empty, err);

            var cats = await _productService.GetCategoriesAsync();
            ViewBag.Categories = cats.Data ?? new List<Category>();

            return View(product);
        }

        return RedirectToAction(nameof(GetAllProduct));
    }
}
