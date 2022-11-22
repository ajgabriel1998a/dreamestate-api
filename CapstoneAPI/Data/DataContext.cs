
using CapstoneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Properties> Properties { get; set; }
    }
}
