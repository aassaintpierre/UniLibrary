using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication_LibraryManagementProject.Models
{
    public class UNILibraryDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
    }
}