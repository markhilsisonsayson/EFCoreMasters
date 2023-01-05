using InventoryAppEFCore.DataLayer.EfClasses;
using InventoryAppEFCore.DataLayer.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Metadata;

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
        public DbSet<VW_Product> VW_Products { get; set; }

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

            //One to One
            modelBuilder.Entity<LineItem>()
                .HasOne(b => b.Product)
                .WithOne(b=>b.LineItem)
            .HasForeignKey<LineItem>(b => b.ProductId);

            //One to many
            modelBuilder
                .Entity<Review>()
                .HasOne<Product>(e=>e.Product)
                .WithMany(d=>d.Reviews)
                .HasForeignKey(e=>e.ProductId);

            //Many to Many
            modelBuilder
                .Entity<Tag>()
                .HasMany(p => p.Products)
                .WithMany(p => p.Tags)
                .UsingEntity(j => j.ToTable("ProductTags"));

            //Global query
            modelBuilder
                .Entity<Client>().HasQueryFilter(p => !p.IsDeleted);

            //Model Seed Data
            modelBuilder
                .Entity<Supplier>().HasData(new Supplier { SupplierId = 100, Name = "Supplier 100", Description = "Supplier 100 Desc" });

            //Add View
            modelBuilder
                .Entity<VW_Product>()
                .ToView(nameof(VW_Products))
                .HasKey(t => t.ProductId);
        }
    }
}