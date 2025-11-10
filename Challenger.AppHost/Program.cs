using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Challenger_API>("challenger-api");

builder.Build().Run();