using Microsoft.AspNetCore.Mvc;
using ProductApi.Model;
using ProductApi.Repository;

namespace ProductApi.Controllers
{ 
    [Route("Products")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IProductRepository _repo;
        public OrderController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = _repo.GetAllProducts(); 
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        { 
            var products = await _repo.CreateProduct(product);
            if (products == null) return BadRequest("All Feilds Required");
            return Created("Product Added Successfully!!", new Product { Id=product.Id, Name = product.Name, price = product.price});
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid Id) {
            var product = await _repo.GetProductById(Id);
            if (product == null) return BadRequest();
            return Ok(product);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put([FromBody]Product product, [FromRoute]Guid Id) {
            var isUpdated = await _repo.UpdateProduct(Id, product);
            return Ok("Updated Successfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
           await _repo.DeleteProduct(Id);
            return Ok("Deleted product Successfully");
        }
    }
}
