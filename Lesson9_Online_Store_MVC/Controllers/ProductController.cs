using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Lesson9_Online_Store_DataAccess.Repositories.Concrete;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Lesson9_Online_Store_MVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProduct() => View(await _productRepository.GetAllAsync());


    [HttpGet]
    public async Task<IActionResult> AddProduct()
    {
        ViewBag.Categories = await _categoryRepository.GetAllAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = await _categoryRepository.GetAllAsync();
            return View(product);
        }

        await _productRepository.AddAsync(product);
        return RedirectToAction(nameof(GetAllProduct));
    }



}
