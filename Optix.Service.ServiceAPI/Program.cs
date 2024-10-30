using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Optix.Service.ServiceAPI.Data;
using Optix.Service.ServiceAPI.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OptixServiceServiceAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OptixServiceServiceAPIContext") ?? throw new InvalidOperationException("Connection string 'OptixServiceServiceAPIContext' not found.")));

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

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
