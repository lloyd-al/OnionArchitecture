using System;


namespace OnionArchitecture.Catalog.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        int Complete();

    }
}
