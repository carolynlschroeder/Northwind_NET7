using Microsoft.AspNetCore.Mvc;
using Northwind_NET7_API.Data;
using Northwind_Net7_Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind_NET7_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        public IQueryable<Category>  Get()
        {
            return _context.Categories;
        }

        // GET api/<CategoriesController>/5
        

        [HttpGet("/Categories/GetJpegImages", Name = "GetJpegImages")]
        public string[] GetJpegImages()
        {
            var categories = _context.Categories.ToList();
            var array = new string[categories.Count()];
            for (int i = 0; i < categories.Count(); i++)
            {
                array[i] = GetJpegImage(categories[i].CategoryId);
            }

            return array;
        }

        private string GetJpegImage(int id)
        {
            var category = _context.Categories.Find(id);
            var imageBytes = category.Picture;
            var base64Str = string.Empty;
            using (var ms = new MemoryStream())
            {
                int offset = 78;
                ms.Write(imageBytes, offset, imageBytes.Length - offset);
                var bmp = new System.Drawing.Bitmap(ms);
                using (var jpegms = new MemoryStream())
                {
                    bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    base64Str = Convert.ToBase64String(jpegms.ToArray());
                }
            }

            return $"data:image/jpeg;base64,{base64Str}";
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
