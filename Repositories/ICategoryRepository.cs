using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoryProducts();
        Task<Category> GetCategoryById(int categoryId);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int categoryId);
    }
}