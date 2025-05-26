using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO categoryDto)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> categoriesEntity = await _repository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            IEnumerable<Category> categoriesEntity = await _repository.GetCategoryProducts();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int categoryId)
        {
            Category categoryEntity = await _repository.GetCategoryById(categoryId);

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task RemoveCategory(int categoryId)
        {
            Category categoryEntity = await _repository.GetCategoryById(categoryId);
            await _repository.Delete(categoryEntity.CategoryId);
        }

        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Update(categoryEntity);
        }
    }
}