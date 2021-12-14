using Catalog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DataAccess.Concrete
{
    public class CatalogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CatalogDB;integrated security=true;");
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Catagories { set; get; }
    }
}
