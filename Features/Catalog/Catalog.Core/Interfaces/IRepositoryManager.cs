using System.Collections.Generic;
using System.Threading.Tasks;
using OnionArchitecture.Catalog.Core.Entities;

namespace OnionArchitecture.Catalog.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        void Save();
    }
}
