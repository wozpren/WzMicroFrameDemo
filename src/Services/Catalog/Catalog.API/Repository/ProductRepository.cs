using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context)); 
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, category);

            return await _context.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.Products
                .Find(filter)
                .ToListAsync();
        }



        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }
        public async Task<bool> Update(Product product)
        {
            var result = await _context.Products
                .ReplaceOneAsync(p => p.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }


        public async Task<bool> Delete(string id)
        {
            var result = await _context.Products
                .DeleteOneAsync(p => p.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }



    }
}
