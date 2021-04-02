using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public  async Task <IActionResult> GetAll()
        {
            return Json(new { data = await _context.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task< IActionResult> Delete( int id)
        {
            var bookFromDb = await _context.Book.FirstOrDefaultAsync(u =>u.Id == id);
            if(bookFromDb==null)
            {
                return Json(new { sucess = false, message = " Error occured while deleting" });
            }
            _context.Book.Remove(bookFromDb);
            await _context.SaveChangesAsync();

            return Json(new { sucess = true, message = " Deleted successfully" });
        }
    }
}
