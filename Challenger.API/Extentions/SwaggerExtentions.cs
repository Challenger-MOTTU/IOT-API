using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Challenger.API.Extentions
{
    public static class SwaggerExtentions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Challenger API",
                    Version = "v1"
                });

                c.SupportNonNullableReferenceTypes();
            });

            return services;
        }
    }
}