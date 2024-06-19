using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string searchQuery = null)
    {
        var products = string.IsNullOrWhiteSpace(searchQuery)
            ? await _productService.GetAllAsync()
            : await _productService.SearchAsync(searchQuery);

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}