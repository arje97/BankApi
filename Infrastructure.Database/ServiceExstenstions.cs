using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfBank, UnitOfBank>();
            services.AddDbContext<BankApi_DbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection")));
        }


    }
}
