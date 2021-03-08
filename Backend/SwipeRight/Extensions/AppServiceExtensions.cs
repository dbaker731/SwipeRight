using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repo;
using Service;
using SwipeRight.Interfaces;
using SwipeRight.Services;

namespace SwipeRight.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration congif)
        {
            services.AddScoped<SwipeRightDbContext>();
            services.AddScoped<Repository>();
            services.AddScoped<Logic>();
            services.AddScoped<Mapper>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
