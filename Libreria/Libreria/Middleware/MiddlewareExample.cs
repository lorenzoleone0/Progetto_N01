using Libreria.Abstractions.IService;

namespace Libreria.Middleware
{
    public class MiddlewareExample 
    {
        private RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context
            , IUtenteService utenteService
            , ILibroService libroService
            , ICategoriaService categoriaService
            , IConfiguration configuration
            )
        {
            context.RequestServices.GetRequiredService<IUtenteService>();
            context.RequestServices.GetRequiredService<ILibroService>();
            context.RequestServices.GetRequiredService<ICategoriaService>();
            
           
            await _next.Invoke(context);
        }
    }
}

