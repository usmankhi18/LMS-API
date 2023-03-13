using LMS_API.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataAccess library;
        public BookController(IDataAccess library) {
            this.library = library;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetALlBooks()
        {
            var books = library.GetAllBooks();
            var booksToSend = books.Select(book => new
            {
                book.Id,
                book.Title,
                book.Category.Category,
                book.Category.SubCategory,
                book.Price,
                Available = !book.Ordered,
                book.Author,
                book.LogoPath
            }).ToList();
            return Ok(booksToSend);
        }
    }
}
