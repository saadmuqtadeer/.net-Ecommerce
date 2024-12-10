using ProductApi.Model;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
        public Task<Product> CreateProduct(Product product);
        public IEnumerable<Product> GetAllProducts();
        public Task<Product> GetProductById(Guid id);
        public Task<bool> UpdateProduct(Guid Id, Product product);
        public Task<bool> DeleteProduct(Guid Id);
    }
}
