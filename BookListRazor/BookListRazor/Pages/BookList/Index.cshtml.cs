using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> books { get; set; }
        public async Task OnGet()
        {
            books = await _context.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete( int Id)
        {
            var BookDel = await _context.Book.FindAsync(Id);
            if (BookDel == null)
            {
                return NotFound();
            }
          _context.Remove(BookDel);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
