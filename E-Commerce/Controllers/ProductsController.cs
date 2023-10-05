using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using E_Commerce.Data;
using E_Commerce.DTOs;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IGenericRepository<Product> _productRepo { get; }
        public IGenericRepository<ProductBrand> _productBrandRepo { get; }
        public IGenericRepository<ProductType> _productTypeRepo { get; }

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
           _productRepo = productRepo;
           _productBrandRepo = productBrandRepo;
           _productTypeRepo = productTypeRepo;
           _mapper = mapper;
        }  

        [HttpGet]
        public async  Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpesification();
           var products=await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpesification(id);
            var product=await _productRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDTO>(product);
        }
        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypeBrand()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
