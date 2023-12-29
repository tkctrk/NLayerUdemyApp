using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using NLayerRepository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository
{
    public class AppDbContext :DbContext
    {
        private Assembly assembly;

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature
            {
                Id = 2,
                Color = "Mavi",
                Height = 100,
                Width = 300,
                ProductId = 2,
            });
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
