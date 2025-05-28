using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.services;

namespace VShop.ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            IEnumerable<CategoryDTO> categoriesDTO = await _service.GetCategories();

            if (categoriesDTO is null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            IEnumerable<CategoryDTO> categoriesDTO = await _service.GetCategoriesProducts();

            if (categoriesDTO is null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryById(int categoryId)
        {
            CategoryDTO categoryDTO = await _service.GetCategoryById(categoryId);

            if (categoryDTO is null)
                return NotFound("Category not found");

            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return BadRequest("Invalid Data");

            await _service.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("CreateCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO.CategoryId != categoryId)
                return BadRequest();

            if (categoryDTO is null)
                return BadRequest();

            await _service.UpdateCategory(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            CategoryDTO categoryDTO = await _service.GetCategoryById(categoryId);

            if (categoryDTO is null)
                return BadRequest("Category not found");

            await _service.RemoveCategory(categoryDTO.CategoryId);

            return Ok(categoryDTO);
        }
    }
}