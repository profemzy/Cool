﻿using Microsoft.EntityFrameworkCore;

namespace Cool.Models.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
