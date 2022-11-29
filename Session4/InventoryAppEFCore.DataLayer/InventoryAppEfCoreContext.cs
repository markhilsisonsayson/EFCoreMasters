using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO Fluent API
            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder
                .Entity<Client>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder
                .Entity<Supplier>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            //Shadow properties
            modelBuilder
                .Entity<Product>()
                .Property<DateTime>("LastUpdated");

            //Backing Fields
            modelBuilder
                .Entity<PriceOffer>()
                .Property(p => p.NewPrice)
                .HasField("_newPrice");

            //Value Converter
            modelBuilder
                .Entity<Order>()
                .Property(e=>e.Status)
                .HasConversion(v=>v.ToString(),
                v=>(OrderStatus)Enum.Parse(typeof(OrderStatus),v));

            //Not Mapped via Fluent API
            modelBuilder
                .Entity<Supplier>()
                .Ignore(b => b.ExcludedClass);

            modelBuilder
                .Ignore<ExcludeClass>();

        }
    }
}