using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using OnionArchitecture.Common.Core.Interfaces;
using OnionArchitecture.Common.Infrastructure.Services;


namespace OnionArchitecture.Catalog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Catalog API",
                    Version = "v1"
                });
            });
        }


        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        // Add API Versioning to the Project
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);

                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;

                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;

                // Supporting multiple versioning scheme
                config.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("X-version"), new QueryStringApiVersionReader("api-version"));
            });
        }

        public static void ConfigureMailService(this IServiceCollection services) =>
            services.AddTransient<IEmailService, EmailService>();
    }
}
