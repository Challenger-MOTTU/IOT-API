using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Challenger.Infrastructure.ComputerVision;

var builder = WebApplication.CreateBuilder(args);

// =========================================
// CONTROLLERS
// =========================================
builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";    // gera v1, v2
        options.SubstituteApiVersionInUrl = true;
    });

// =========================================
// SWAGGER – COMPATÍVEL COM ROUTES E V1/V2
// =========================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =========================================
// ROBOFLOW + HEALTHCHECKS
// =========================================
builder.Services.AddHttpClient<RoboflowService>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// =========================================
// SWAGGER UI (com v1 e v2 corretamente)
// =========================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
        options.RoutePrefix = "swagger";
    });
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();