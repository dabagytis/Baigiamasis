using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Models.Knygos;
using Baigiamasis.Core.Utils;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Baigiamasis.API.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("AddDigitalBook")]
        public void AddDigitalBook(DigitalBook book)
        {
            Log.Information("AddDigitalBook request received");
            try
            {
                _bookService.AddBook(book);
                Log.Information("AddDigitalBook request completed");

            }
            catch(Exception e)
            {
                Log.Error($"Could not complete method AddDigitalBook. Exception thrown {e.Message}");
            }
        }

        [HttpPost("AddPrintBook")]
        public void AddPrintBook(PrintBook book)
        {
            Log.Information("AddPrintBook request received");
            try
            {
                _bookService.AddBook(book);
                Log.Information("AddPrintBook request completed");

            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddPrintBook. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {        
            Log.Information("GetAllBooks request received");
            try
            {
                var x = JsonCustomConverter.SerializeWithPolymorphism(_bookService.GetAllBooks());
                Log.Information("GetAllBooks request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllBooks. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            Log.Information("GetBookById request received");
            try
            {
                var x = _bookService.GetBookById(id);
                Log.Information("GetBookById request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetBookById. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpDelete("RemoveBook")]
        public void RemoveBook(int id)
        {
            Log.Information("RemoveBook request received");
            try
            {
                _bookService.RemoveBook(id);
                Log.Information("RemoveBook request completed");

            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method RemoveBook. Exception thrown {e.Message}");
            }
        }

        [HttpGet("SearchByCategory")]
        public IActionResult SearchByCategory(string category)
        {
            Log.Information("SearchByCategory request received");
            try
            {
                var x = _bookService.SearchByCategory(category);
                Log.Information("SearchByCategory request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method SearchByCategory. Exception thrown {e.Message}");
            }
            return NotFound();
        }
    }
}
