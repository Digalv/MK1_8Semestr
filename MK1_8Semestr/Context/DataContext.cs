using Microsoft.EntityFrameworkCore;
using MK1_8Semestr.Entity;

namespace MK1_8Semestr.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
