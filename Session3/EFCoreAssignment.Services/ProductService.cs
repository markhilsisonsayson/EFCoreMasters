using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext appDbContext;

        public ProductService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            var products = appDbContext.Products;
            var productsDtoList = new List<ProductDto>();
            if (products is not null) {
                productsDtoList = await products.Select(c => new ProductDto(c.Id, c.Name, c.ShopId)).ToListAsync();
            }
            return productsDtoList;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = appDbContext.Products.Find(id);
            if (product is null) throw new ArgumentNullException(nameof(product));   
            var productDto = new ProductDto(product.Id, product.Name, product.ShopId);
            return productDto;
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            var product = new Product();
            product.Name = productForCreation.Name;
            product.ShopId = productForCreation.ShopId;

            await appDbContext.Products.AddAsync(product);
            return await appDbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = new Product();
            product.Id = productForUpdate.Id;
            product.Name = productForUpdate.Name;
            product.ShopId = productForUpdate.ShopId;

            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var product = appDbContext.Products.Find(id);

            if (product is null) throw new ArgumentNullException(nameof(product));
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
        }
    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}