using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Infra;
using PicPaySimplificado.Repository.Carteira;
using PicPaySimplificado.Repository.Transferencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var serverVersion = new MySqlServerVersion(new Version(9, 3, 0));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        serverVersion,
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    )
);

builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseAuthorization();

app.MapControllers();

app.Run();
