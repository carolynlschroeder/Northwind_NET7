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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
