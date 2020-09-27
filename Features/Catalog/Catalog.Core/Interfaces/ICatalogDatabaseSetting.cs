using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Catalog.Core.Interfaces
{
    public interface ICatalogDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
