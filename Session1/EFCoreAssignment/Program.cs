// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = @"Server=SVPHLP00642\SQLEXPRESS;Database=EFCoreMasters.Session01;Trusted_Connection=True;MultipleActiveResultSets=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext);
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name
    dbContext.Products.Where(c => c.Name == "Dress").ToList();
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id   
    dbContext.Products.SingleOrDefault(c=>c.Id==1);
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    var books = dbContext.Products;
    var shops = dbContext.Shops;
    foreach (var book in books)
    {
        book.Shop = shops.Where(m=>m.Id==book.Id).FirstOrDefault() ;
    }
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
    var products = dbContext.Products.FirstOrDefault();
    dbContext.Entry(products).Reference(b => b.Shop).Load();
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly
   dbContext.Products.Include(c=>c.Shop).ToList();
}


Console.WriteLine("EF Core is the best");
