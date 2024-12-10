using Microsoft.EntityFrameworkCore;
using ProductApi.Model;

namespace ProductApi.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }
        public DbSet<Product> products {  get; set; }
    }
}
