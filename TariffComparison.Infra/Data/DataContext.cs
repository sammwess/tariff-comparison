using Microsoft.EntityFrameworkCore;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}