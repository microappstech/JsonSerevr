using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Context;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context; 
        }
        [HttpGet]
        //[DisableCors]
        public async Task<IEnumerable<Categories>> GetCategories()
        {
            var cotes = _context.Categories;
            return await Task.FromResult(cotes);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] CategoriesDto categoriesDto )
        {
            var categories = new Categories()
            {
                name = categoriesDto.name,
                image = categoriesDto.image,
                type = categoriesDto.type

            };
            _context.Categories.Add(categories);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception Ex)
            {

            }
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
            var category = _context.Categories.Find(id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                try
                {
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
