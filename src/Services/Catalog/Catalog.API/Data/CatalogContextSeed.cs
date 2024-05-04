using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "IPhone X",
                    Category = "Smart Phone",
                    Summary = "This is the summary of the product",
                    Description = "This is the long description of the product",
                    ImageFile = "product-1.png",
                    Price = 950.00M
                },
                new Product
                {
                    Name = "Samsung 10",
                    Category = "Smart Phone",
                    Summary = "This is the summary of the product",
                    Description = "This is the long description of the product",
                    ImageFile = "product-2.png",
                    Price = 840.00M
                },
                new Product
                {
                    Name = "Huawei Plus",
                    Category = "White Appliances",
                    Summary = "This is the summary of the product",
                    Description = "This is the long description of the product",
                    ImageFile = "product-3.png",
                    Price = 420.00M
                }
            };
        }
    }
}
