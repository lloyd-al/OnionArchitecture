using System;

using OnionArchitecture.Catalog.Core.Interfaces;

namespace OnionArchitecture.Catalog.Infrastructure.Settings
{
    public class CatalogDatabaseSetting : ICatalogDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
