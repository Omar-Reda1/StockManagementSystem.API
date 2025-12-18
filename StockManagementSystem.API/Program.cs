using Microsoft.EntityFrameworkCore;
using Scalar;
using Scalar.AspNetCore;
using StockManagementSystem.API.DataAccess;
using StockManagementSystem.API.Repositories;
using StockManagementSystem.API.Repositories.IRepositories;
namespace StockManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var connectionString =
                  builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? throw new InvalidOperationException("Connection string"
                      + "'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IStockRepository,StockRepository>();
            builder.Services.AddScoped<ICommentRepository,CommentRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
