using MongoDB.Driver;

using OnionArchitecture.Catalog.Core.Entities;
using OnionArchitecture.Catalog.Core.Interfaces;
using OnionArchitecture.Common.Core.Interfaces;


namespace OnionArchitecture.Catalog.Infrastructure.DataContexts
{
    public class CatalogDbContext : ICatalogDbContext
    {
        private readonly IDateTimeService _dateTime;

        public CatalogDbContext(ICatalogDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);

            CatalogDbContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
