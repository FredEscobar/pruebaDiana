using System;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LibraryContext :  DbContext
    {
     
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
