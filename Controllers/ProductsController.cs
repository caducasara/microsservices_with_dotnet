using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.services;

namespace VShop.ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            IEnumerable<ProductDTO> productDTO = await _service.GetProducts();

            if (productDTO is null)
                return NotFound("Products not found");

            return Ok(productDTO);
        }

        [HttpGet("id:int", Name = "GetProductsById")]
        public async Task<ActionResult<ProductDTO>> GetProductsById(int productId)
        {
            ProductDTO productDTO = await _service.GetProductById(productId);

            if (productDTO is null)
                return NotFound("Products not found");

            return Ok(productDTO);
        }

        [HttpGet("categoryid:int", Name = "GetProductsByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<ProductDTO> productDTO = await _service.GetProductsByCategory(categoryId);

            if (productDTO is null)
                return NotFound("Products not found");

            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest("Invalid Data");

            await _service.AddProduct(productDTO);

            return new CreatedAtRouteResult("CreateProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest();

            await _service.UpdateProduct(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            ProductDTO productDTO = await _service.GetProductById(productId);

            if (productDTO is null)
                return BadRequest("Category not found");

            await _service.RemoveProduct(productDTO.Id);

            return Ok(productDTO);
        }
    }
}