using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EMG.API.Data;
using EMG.API.Services;
using EMG.API.Modeles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Ajouter le DbContext
builder.Services.AddDbContext<ContexteApplication>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnexionParDefaut")));

// Ajouter le service en injection de dépendances
builder.Services.AddScoped<IServiceVoiture, ServiceVoiture>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "EMG API", 
        Version = "v1",
        Description = "API de gestion des voitures EMG"
    });
});

builder.Services.AddDbContext<ContexteApplication>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnexionParDefaut")));

builder.Services.AddScoped<IServiceVoiture, ServiceVoiture>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
