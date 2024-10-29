using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Abstractions.Service;
using Libreria.Application.Services;
using Libreria.Entita;
using Libreria.Repositories;
using Libreria.Request;
using Libreria.Validatori;


namespace Libreria.ServiceExtensions
{
    public static class ServiceExtensionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddValidatorsFromAssembly(
                AppDomain.CurrentDomain.GetAssemblies()
                    .SingleOrDefault(assembly => assembly.GetName().Name == "Libreria")
            );

           
            services.AddScoped<IUtenteService, UtenteService>();  
            services.AddScoped<ILibroService, LibroService>();  
            services.AddScoped<ICategoriaService, CategoriaService>();  
            services.AddScoped<ITokenService, TokenService>();  
            
            
            
            

            return services;
        }

    }
}

