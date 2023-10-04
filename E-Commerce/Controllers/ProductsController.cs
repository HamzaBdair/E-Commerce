using Core.Interfaces;
using E_Commerce.Data;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GetProducts()
        {
           var products=await _repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }
        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _repository.GetProductBrandsAsync());
        }
        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypeBrand()
        {
            return Ok(await _repository.GetProductTypesAsync());
        }
    }
}
