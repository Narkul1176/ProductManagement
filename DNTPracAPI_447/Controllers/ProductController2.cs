using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstraction;

namespace DNTPracAPI_447.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController2 : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController2(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        [Route("DisplayAllProducts")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepo.GetAllProducts();
                if (products != null)
                {
                    return StatusCode(StatusCodes.Status200OK, products);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
            
        }
    }
}
