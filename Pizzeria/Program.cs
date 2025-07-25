using Data;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PizzaData>();
builder.Services.AddScoped<PizzaBusiness>();
builder.Services.AddScoped<PedidoData>();
builder.Services.AddScoped<PedidoBusiness>();
builder.Services.AddScoped<ClienteData>();
builder.Services.AddScoped<ClienteBusiness>();
builder.Services.AddScoped<UserData>();
builder.Services.AddScoped<UserBusiness>();
builder.Services.AddScoped<RolData>();
builder.Services.AddScoped<RolBusiness>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
