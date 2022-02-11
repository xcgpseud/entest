using Database.Contexts;
using Database.Repositories;
using Database.Repositories.Interfaces;
using Ensek.Services;
using Ensek.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SqliteContext>();

// I'd have this extracted out but I am short on time so leaving here for now!
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMeterReadingRepository, MeterReadingRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMeterReadingService, MeterReadingService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
