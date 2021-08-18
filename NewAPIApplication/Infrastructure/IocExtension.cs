using API.Data;
using API.Data.Repository;
using API.Data.SqlConnection;
using API.Models.Models;
using API.Models.Repository;
using API.Models.Services;
using API.Services.Services;
using APIApplication.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace APIApplication.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class IocExtension
    {
        public static IServiceCollection BuildContainer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionSection = configuration.GetSection("ConnectionStrings");
            var connectionStrings = connectionSection.Get<ConnectionStrings>();            

            services.AddHttpContextAccessor();
            services.AddSingleton<MongoDatabase>();// register the mongodb connection
            services.AddTransient<IConnection, Connection>(); //register the connections sql and oracle

            //register the repository
            services.AddTransient<IBooksRepository, BooksRepository>();

            //register the services
            services.AddTransient<IBooksService, BooksService>();

            services.AddSingleton(connectionStrings);
            return services;
        }
    }
}
