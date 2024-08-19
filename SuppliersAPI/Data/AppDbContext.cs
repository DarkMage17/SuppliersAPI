using Microsoft.EntityFrameworkCore;
using SuppliersAPI.Entities;

namespace SuppliersAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
