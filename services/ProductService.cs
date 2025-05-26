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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO ProductDto)
        {
            Product productEntity = _mapper.Map<Product>(ProductDto);
            await _repository.Create(productEntity);
            ProductDto.Id = productEntity.Id;
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            Product productEntity = await _repository.GetProductById(productId);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> productsEntity = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product> producstEntity = await _repository.GetProductsByCategory(categoryId);

            return _mapper.Map<IEnumerable<ProductDTO>>(producstEntity);
        }

        public async Task RemoveProduct(int productId)
        {
            Product productEntity = await _repository.GetProductById(productId);
            await _repository.Delete(productEntity.Id);
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            Product productEntity = _mapper.Map<Product>(productDto);
            await _repository.Update(productEntity);
        }
    }
}