using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using OnionArchitecture.Catalog.Core.Interfaces;
using OnionArchitecture.Catalog.Infrastructure.DataContexts;
using OnionArchitecture.Catalog.Infrastructure.Repositories;
using OnionArchitecture.Catalog.Infrastructure.Settings;


namespace OnionArchitecture.Catalog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CatalogDatabaseSetting>(x => configuration.GetSection(nameof(CatalogDatabaseSetting)).Bind(x));

            services.AddSingleton<ICatalogDatabaseSetting>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSetting>>().Value);

            services.AddTransient<ICatalogDbContext, CatalogDbContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
