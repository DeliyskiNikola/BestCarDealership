using BestCarDealership.BL.Interfaces;
using BestCarDealership.BL.Services;

using BestCarDealership.DL;
using BestCarDealership.DL.Interfaces;
using BestCarDealership.DL.Repositories;
using BestCarDealership.HealthChecks;

using FluentValidation;
using FluentValidation.AspNetCore;

namespace BestCarDealership
{
    public static class Startup
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ICarRepository, CarRepository>();
            builder.Services.AddSingleton<IDealershipRepository, DealershipRepository>();

            builder.Services.AddSingleton<ICarService, CarService>();
            builder.Services.AddSingleton<IDealershipService, DealershipService>();
            builder.Services.AddSingleton<ICarDealershipService, CarDealershipService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Startup));

            builder.Services.AddHealthChecks().AddCheck<CarDealershipHealthCheck>(nameof(CarDealershipHealthCheck));

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

            app.MapHealthChecks("/healthz");

            app.Run();
        }

        private static WebApplication GetApp(WebApplicationBuilder builder)
        {
            return builder.Build();
        }
    }
}
    
