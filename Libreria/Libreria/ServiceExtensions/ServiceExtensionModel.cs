using Microsoft.EntityFrameworkCore;
using Libreria.Database;
using Libreria.Repositories;


namespace Libreria.ServiceExtensions
{
    public static class ServiceExtensionModel
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"))
                .EnableSensitiveDataLogging()  
                .LogTo(Console.WriteLine, LogLevel.Information);

            });

            
            services.AddScoped<UtenteRepository>();       
            services.AddScoped<LibroRepository>();      
            services.AddScoped<CategoriaRepository>();   
            

            return services;
        }
    }
}