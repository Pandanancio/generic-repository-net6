using GenericRepository_NET6.Data;
using GenericRepository_NET6.Repositories;
using GenericRepository_NET6.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IPetService, PetService>();
services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

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
