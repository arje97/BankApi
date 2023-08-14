using Core.Application.Services;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddAppLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<UserService>();
            services.AddScoped<LoanService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddMvc().AddFluentValidation();

        }
    }
}
