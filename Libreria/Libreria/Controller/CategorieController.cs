using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.ModelsDto;
using Libreria.Request;
using Libreria.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CategorieController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IValidator<CreateCategoriaRequest> _validator;
        public CategorieController(ICategoriaService categoriaService, IValidator<CreateCategoriaRequest> validator)
        {
            _categoriaService = categoriaService;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound(new { Messaggio = "Categoria non trovata." }); 
            }
            return Ok(categoria); 
        }


        [HttpPost]
        [Route("new")]
        
        public async Task<IActionResult> CreaCategoriaAsync(CreateCategoriaRequest request)
        {
            var validationResult = _validator.Validate(request);

            var categoria = request.ToEntity();
            await _categoriaService.AggiungiCategoriaAsync(categoria);

            var response = new CreateCategoriaResponse();
            response.Categoria = new CategoriaDto(categoria);
            return Ok(ResponseFactory.WithSuccess(response));
            
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> EliminaCategoriaAsync(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound(new { Messaggio = "Categoria non trovata." });
            }

            await _categoriaService.EliminaCategoriaAsync(id); 
           

            return Ok(new { Messaggio = "Categoria eliminata con successo.", NomeCategoria = categoria.Nome });

        }
    }
}

