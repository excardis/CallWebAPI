using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallWebBackend.Database
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=excard-database-1.cellesmw0jhe.ap-southeast-1.rds.amazonaws.com; port=3306; database=excardmaster; user=admin_ms; password=exmaster@#8005;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("product");
            builder.Entity<ProductGroup>().ToTable("product_group");
            builder.Entity<User>().ToTable("user");

            builder.Entity<ProductGroup>().HasOne(u => u.Product).WithMany(x => x.ProductGroups).HasForeignKey(i => i.ProductId);
        }
    }
}
