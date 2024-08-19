
using FlamingoAirwaysAPI.Models;
using FlamingoAirwaysAPI.Models.Interfaces.cs;
using FlamingoAirwaysAPI.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;

namespace FlamingoAirwaysAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<FlamingoAirwaysDB>

    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("nwCnString")));

            builder.Services.AddScoped<IFlightRepository, FlightRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();



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
        }
    }
}