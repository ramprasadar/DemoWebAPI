using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoWebAPI.Models;
using DemoWebAPI.Data;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        private List<Product> products = new List<Product>();

        [HttpGet("getallproducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            
            products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("getbyid/{id}")]
        
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<ActionResult> AddProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        
        [HttpPut("update")]
        public async Task<ActionResult<List<Product>>> UpdateProduct (Product p)
        {
            var dbproduct = await _context.Products.FindAsync(p.Id);
            if (dbproduct == null)
                return BadRequest("Product not found.");

            dbproduct.Name = p.Name;
            dbproduct.Qty = p.Qty;
            dbproduct.Price = p.Price;
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<List<Product>>> Delete(int id)
        {
            var dbproduct = await _context.Products.FindAsync(id);
            if (dbproduct == null)
                return BadRequest("Product not found.");
            
            _context.Products.Remove(dbproduct);
            await _context.SaveChangesAsync();
            return Ok(await _context.Products.ToListAsync());

        }
    }
}
