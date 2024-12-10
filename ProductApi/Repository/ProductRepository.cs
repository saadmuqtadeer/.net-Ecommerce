using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Model;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product == null) return product;
            else { 
                await _context.products.AddAsync(product);
                _context.SaveChanges();
            }
            return product;
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == Id);
            if(product != null) {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.products.ToList();
        }

        public async Task<Product> GetProductById(Guid Id)
        {
            var product = await _context.products.FirstOrDefaultAsync(p => p.Id == Id);
            return product;
        }

        public async Task<bool> UpdateProduct(Guid Id, Product product)
        {
            var existingProduct = await _context.products.FirstOrDefaultAsync(p => p.Id == Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.price = product.price;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
