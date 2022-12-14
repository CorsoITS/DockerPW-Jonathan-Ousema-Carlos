using catalogo.Context;
using catalogo.Repositories;
using catalogo.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("MySql");

builder.Services.AddTransient<AppDb>(appDb => new AppDb(connectionString));

builder.Services.AddTransient<CatalogItemRepository>();
builder.Services.AddTransient<CatalogItemService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
