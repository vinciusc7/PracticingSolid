using Microsoft.EntityFrameworkCore;
using Simplecrud.Context;
using Simplecrud.Repository;
using Simplecrud.Services;

var builder = WebApplication.CreateBuilder(args);

string mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mysqlConnection,
    ServerVersion.AutoDetect(mysqlConnection)));

// Add services to the container.

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
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
