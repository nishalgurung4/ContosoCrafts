using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public JsonFileProductService ProductService { get; }

    /**
     * IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. 
     * This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement
     **/
    public IEnumerable<Product>? Products { get; private set; }

    /**
     * OnGet to handle GET Request
     **/
    public void OnGet() => Products = ProductService.GetProducts();

    public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
    {
        _logger = logger;
        ProductService = productService;

    }
}

