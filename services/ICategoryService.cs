using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoryById(int categoryId);
        Task AddCategory(CategoryDTO categoryDto);
        Task UpdateCategory(CategoryDTO categoryDto);
        Task RemoveCategory(int categoryId);
    }
}