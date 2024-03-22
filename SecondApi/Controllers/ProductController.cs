using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondApi.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondApi.Controllers
{
 
    public class ProductController : BaseApiController
    {
        public readonly IGeneticRepository<Product> _productsrepo;
        public readonly IGeneticRepository<ProductBrand> _productsbrandsrepo;
        public readonly IGeneticRepository<ProductType> _producttypessrepo;
        private readonly IMapper _mapper;

        public ProductController(IGeneticRepository<Product> productsrepo, IGeneticRepository<ProductBrand> productsbrandsrepo, IGeneticRepository<ProductType> producttypessrepo, IMapper mapper) {
            _productsrepo=productsrepo;
            _productsbrandsrepo=productsbrandsrepo;
            _producttypessrepo=producttypessrepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new PoductsWithTypesAndBrandSpec(productParams);
          
            var products =await _productsrepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products));
        }
        [HttpGet("{id:int}")]

        public async Task<ActionResult<ProductToReturn>> GetProductDetails(int id)
        {
            var spec = new PoductsWithTypesAndBrandSpec(id);
            var product = await _productsrepo.GetEnityWithSpec(spec);
            return _mapper.Map<Product,ProductToReturn>(product);
            
            
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductsBrands()
        {
            var products = await _productsbrandsrepo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductsTypes()
        {
            var products = await _producttypessrepo.GetAllAsync();
            return Ok(products);
        }
    }
}
