using Microsoft.EntityFrameworkCore;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Interfaces;
using Publicaciones.Infrastructure.Repository;
using Publicaciones.Ioc.Dependencies;

namespace Publicaciones.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            /// Add context dependencies
            builder.Services.AddDbContext<PublicacionesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PubsContext")));

            // Dependencias de los servicios

            builder.Services.AddPubInfoDependency();
            builder.Services.AddRoySchedDependency();
            builder.Services.AddTitlesDependency();


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
        }
    }
}