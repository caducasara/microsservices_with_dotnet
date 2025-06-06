using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Delete(int categoryId)
        {
            var category = await GetCategoryById(categoryId);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Categories
                            .Where(c => c.CategoryId == categoryId)
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryProducts()
        {
            return await _context.Categories
                            .Include(c => c.Products)
                                .ToListAsync();
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }
    }
}