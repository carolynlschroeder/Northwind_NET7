using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind_NET7_API.Data;
using Northwind_Net7_Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind_NET7_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/<ProductsController>
        [HttpGet]
        public List<Product> Get()
        {
            var products =  _context.Products.ToList();
            return products;

        }

        [HttpGet("getByCategory/{categoryId}", Name="GetByCategory")]
        public List<Product> GetByCategory(int categoryId)
        {
            var products = _context.Products.Where(p=>p.CategoryId == categoryId).ToList();
            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProduct")]
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            product.SupplierId = 1;
            product.Discontinued = false;
            
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product.ProductId != id)
            {
                return BadRequest();
            }

            if (_context.Products.AsNoTracking().FirstOrDefault(p=>p.ProductId == id) == null)
            {
                return NotFound();
            }

            try
            {
                //var entry = _context.Entry(contact);
                //entry.State = EntityState.Modified;
                _context.Update(product);
                _context.SaveChanges();
                return new NoContentResult();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
