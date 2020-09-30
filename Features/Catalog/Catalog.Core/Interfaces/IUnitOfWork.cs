using System;


namespace OnionArchitecture.Catalog.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        void Complete();

    }
}
