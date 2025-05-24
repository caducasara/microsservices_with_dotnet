using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(int ProductId);
        Task<Product> Create(Product Product);
        Task<Product> Update(Product Product);
        Task<Product> Delete(int ProductId);
    }
}