using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc;


namespace ContosoCrafts.Controllers
{
    /**
     * [ApiController] enables opinionated behaviors that make it easier to build web APIs.
     * Some behaviors include parameter source inference, attribute routing as a requirement, and model validation error-handling enhancements.
     **/ 
    [ApiController]
    /**
     * [Route] defines the routing pattern [controller].
     * The [controller] token is replaced by the controller's name (case-insensitive, without the Controller suffix).
     *This controller handles requests to https://localhost:{PORT}/products.
     **/
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService) =>
            ProductService = productService;

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            if (request?.ProductId == null)
                return BadRequest();

            ProductService.AddRating(request.ProductId, request.Rating);
            //Creates an OkResult (200 OK).
            return Ok();
        }

        public class RatingRequest
        {
            public string? ProductId { get; set; }
            public int Rating { get; set; }
        }

    }
}

