using System.Configuration;
using WEBAPI_Diego_Rocha.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to string SQL connection
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("SQL");
builder.Services.AddSingleton(connectionString);

builder.Services.AddSingleton<DataAccess>(new DataAccess(connectionString));
builder.Services.AddSingleton<iStudentsInMemory, StudentsSQLServer>(); // Dependency Injection

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
