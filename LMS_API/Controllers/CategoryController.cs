using LMS_API.DataAccess;
using LMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDataAccess library;

        public CategoryController(IDataAccess library) { 
            this.library = library;
        }

        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var categories = library.GetAllCategories();
            var x = categories.GroupBy(c => c.CategoryName).Select(item =>
            {
                return new
                {
                    name = item.Key,
                    children = item.Select(item => new { name = item.SubCategory }).ToList()
                };
            }).ToList();
            return Ok(x);
        }

        [HttpPost("InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {
            category.Name = category.Name;
            category.UserID = category.UserID;
            library.CreateCategory(category);
            return Ok("Inserted");
        }
    }
}
