using Autos.API.Endpoints;
using Autos.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AutosDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);

builder.Services.AddScoped<AutosDAL>();

var app = builder.Build();

app.AddAutosEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();