// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);


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

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    var product = new Product
    {
        Name = "Product new",
        ShopId =1
    };

    dbContext.Add(product);
    dbContext.SaveChanges();
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var product = new Product
    {
        Name = "Product 2",
        Shop = new Shop { Name = "new Shops" }
    };

    dbContext.Add(product);
    dbContext.SaveChanges();
}

static void UpdateProduct(AppDbContext dbContext)
{
    // TODO: Update a Product
    int productId = 1;
    var product = dbContext.Products.Find(productId);
    if (product == null) Console.WriteLine(@$"Couldn't find Product Id [{productId}].");
    else
    {
        product.Name = "New Name";
        dbContext.SaveChanges();
    }
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var productId = 16;
    var product= dbContext.Products.Include(a=>a.Reviews).FirstOrDefault(b=>b.Id== productId);
    if (product == null) Console.WriteLine(@$"Couldn't find Product Id [{productId}].");
    else {
       dbContext.Products.Remove(product);
       dbContext.SaveChanges();
    }
}

static void DeleteProductByKey(AppDbContext dbContext)
{

    // TODO: Delete a Product with just having a key
   int productId = 32;
    var product = new Product()
    {
        Id = productId
    };

   
    dbContext.Products.Remove(product);
    dbContext.SaveChanges();
}

Console.WriteLine("EF Core is the best");
