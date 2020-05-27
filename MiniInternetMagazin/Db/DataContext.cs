using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MiniInternetMagazin.Models.GroceryStoreViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInternetMagazin.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
