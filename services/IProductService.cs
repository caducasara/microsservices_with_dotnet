using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId);
        Task<ProductDTO> GetProductById(int ProductId);
        Task AddProduct(ProductDTO ProductDto);
        Task UpdateProduct(ProductDTO ProductDto);
        Task RemoveProduct(int ProductId);
    }
}