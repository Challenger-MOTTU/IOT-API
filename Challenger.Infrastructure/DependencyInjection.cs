using System;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Challenger.Infrastructure.Percistence.Repositoryes;
using Challenger.Infrastructure.ComputerVision;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenger.Infrastructure


{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CGContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("MotoGridDB"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMotoRepository, MotoRepository>();
            services.AddScoped<IPatioRepository, PatioRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        // Registra HttpClient tipado para o RoboflowService (não precisa de configuração extra)
        public static IServiceCollection AddComputerVision(this IServiceCollection services)
        {
            // Registra um HttpClient para uso no RoboflowService
            services.AddHttpClient<RoboflowService>();
            return services;
        }
    }
    
}