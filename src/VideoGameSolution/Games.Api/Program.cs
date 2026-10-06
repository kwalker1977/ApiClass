using Marten;

var builder = WebApplication.CreateBuilder(args);
builder.AddNpgsqlDataSource("games-db");

builder.AddServiceDefaults();

// Add services to the container.

// add a service that provides the session (IDocumentSession)

builder.Services.AddMarten(options =>
{
    
}).UseNpgsqlDataSource()
.UseLightweightSessions();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();

