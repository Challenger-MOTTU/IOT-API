using System.Reflection;
using Challenger.Application.UseCase;
using Challenger.Application.UseCase.CreateMoto;
using Challenger.Application.UseCase.CreateUser;
using Challenger.Application.UseCase.UpdateUser;
using Challenger.Infrastructure;
using Microsoft.Extensions.DependencyInjection; // necessário para AddHttpClient

namespace Challenger.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Motix API",
                Version = "v1",
                Description = "API com Setores, Motos e Movimentos. CRUD + paginação + HATEOAS."
            });

            // Lê o arquivo XML gerado pelo csproj (XML comments)
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
        });

        // Contexto e Repositórios
        builder.Services.AddDBContext(builder.Configuration);
        builder.Services.AddRepositories();

        // UseCases
        builder.Services.AddScoped<ICreatePatioUseCase, CreatePatioUseCase>();
        builder.Services.AddScoped<IUpdatePatioUseCase, UpdatePatioUseCase>();
        builder.Services.AddScoped<ICreateMotoUseCase, CreateMotoUseCase>();
        builder.Services.AddScoped<IUpdateMotoUseCase, UpdateMotoUseCase>();
        builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

        // HttpClient (para chamar serviços externos, ex: Vision API)
        builder.Services.AddHttpClient();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
