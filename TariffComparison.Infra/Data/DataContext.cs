using Flunt.Notifications;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<CalculationModel>();
            modelBuilder.Entity<CalculationModelBasicElectricityTariff>();
            modelBuilder.Entity<CalculationModelPackagedTariff>();
        }
    }
}