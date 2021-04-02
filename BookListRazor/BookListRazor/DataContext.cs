using BookListRazor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor
{
    public class DataContext :DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        
    }
}
