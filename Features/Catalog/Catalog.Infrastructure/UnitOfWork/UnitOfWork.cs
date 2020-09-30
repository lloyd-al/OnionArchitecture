using System;
using System.Collections.Generic;
using System.Text;

using OnionArchitecture.Catalog.Core.Interfaces;
using OnionArchitecture.Catalog.Infrastructure.DataContexts;
using OnionArchitecture.Catalog.Infrastructure.Repositories;

namespace OnionArchitecture.Catalog.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogDbContext _context;
        public IProductRepository Products { get; private set; }

        public UnitOfWork(CatalogDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }
        public void Complete()
        {
        }

    }
}
