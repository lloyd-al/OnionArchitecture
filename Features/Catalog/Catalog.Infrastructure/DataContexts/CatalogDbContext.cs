using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

using OnionArchitecture.Catalog.Core.Entities;
using OnionArchitecture.Catalog.Core.Interfaces;
using OnionArchitecture.Common.Core.Interfaces;
using OnionArchitecture.Common.Infrastructure.DataContexts;

namespace OnionArchitecture.Catalog.Infrastructure.DataContexts
{
    public class CatalogDbContext : ApplicationDbContext, ICatalogDbContext
    {
        private readonly IDateTimeService _dateTime;

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, ICatalogDatabaseSetting settings, IDateTimeService dateTime) : base(options)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>(settings.CollectionName);

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }


        public IMongoCollection<Product> Products { get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CatalogDbContextSeed.SeedData(Products);
            base.OnModelCreating(builder);
        }
    }
}
