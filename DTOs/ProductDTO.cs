using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}