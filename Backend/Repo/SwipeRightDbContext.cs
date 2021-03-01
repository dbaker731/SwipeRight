using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Repo
{
    public class SwipeRightDbContext : DbContext
    {

        public DbSet<AppUser> Users { get; set; }

        public SwipeRightDbContext() { }

        public SwipeRightDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SwipeRightDevelopment;Trusted_Connection=True;");
            }

        }

    }
}
