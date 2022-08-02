using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PouyanSiteStore
{
    public static class ServicesQueue
    {

        public static IServiceCollection ServicesQueues(this IServiceCollection services)
        {
           
            services.AddScoped<ITransaction, Transaction>();
            services.AddScoped<IPerson, Person>();
            return services;
        }

    }
}
