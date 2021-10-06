using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace FunctionApp28
{
    class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
