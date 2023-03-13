using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString
("FilmeConnection");

builder.Services.AddDbContext<CartazContext>(opts =>
opts.UseSqlServer(connection));



builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod();
    }
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
