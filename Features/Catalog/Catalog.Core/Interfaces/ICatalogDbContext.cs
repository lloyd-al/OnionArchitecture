using MongoDB.Driver;
using OnionArchitecture.Catalog.Core.Entities;

namespace OnionArchitecture.Catalog.Core.Interfaces
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
