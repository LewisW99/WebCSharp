using GameCatalogue.DAL.Data;
using GameCatalogue.BLL.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<GameService>();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<GameCatalogueDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("GameCatalogueDb"),
        sql => sql.MigrationsAssembly("GameCatalogue.API")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVue",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowVue");

app.MapControllers();

app.Run();
