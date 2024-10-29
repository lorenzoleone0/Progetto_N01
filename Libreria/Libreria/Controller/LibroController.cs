using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Application.Models.Responses;
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
    public class LibriController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly IValidator<CreateLibroRequest> _validator;

        public LibriController(ILibroService libroService, IValidator<CreateLibroRequest> validator)
        {
            _libroService = libroService;
            _validator = validator;
        }

        [HttpPost]
        [Route("list")]
        public GetLibriPaginatiResponse GetLibri(GetLibriPaginatiRequest request)
        {
            int totalNum = 0;

            try
            {
                var libri = _libroService.GetLibri(request.PageNumber, request.PageSize, request.Autore, out totalNum);

                var response = new GetLibriPaginatiResponse
                {
                    NumeroPagine = (int)Math.Ceiling(totalNum / (decimal)request.PageSize),
                    Libri = libri.Select(s => new LibroDto(s)).ToList()
                };

                return response;
            }
            catch (Exception ex)
            {
                return new GetLibriPaginatiResponse
                {
                    NumeroPagine = 0,
                    Libri = new List<LibroDto>(),
                    MessaggioErrore = ex.Message 
                };
            }
        }



        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateLibroAsync(CreateLibroRequest request)
        {
          
            var validationResult = await _validator.ValidateAsync(request);


            var libro = request.ToEntity();
            
            await _libroService.AggiungiLibroAsync(libro);

            var response = new CreateLibroResponse();
            response.Libro = new LibroDto(libro);
            return Ok(ResponseFactory.WithSuccess(response));
        }


        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> ModificaLibroAsync(ModificaLibroRequest request)
        {
           
            var libro = await _libroService.GetLibroByIdAsync(request.Id);

            if (libro == null)
            {
                return NotFound($"Libro con id {request.Id} non trovato.");
            }

            
            libro.Titolo = request.Titolo;
            libro.Autore = request.Autore;
            libro.DataPubblicazione = request.DataPubblicazione;
            libro.Editore = request.Editore;
            libro.Categorie = string.Join(", ", request.Categorie);

            await _libroService.ModificaLibroAsync(libro);
            
            return Ok(ResponseFactory.WithSuccess(libro));
        }


        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> EliminaLibroAsync(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound(new { Messaggio = "Libro non trovato." });
            }

            await _libroService.EliminaLibroAsync(id);


            return Ok(new { Messaggio = "Libro eliminato con successo.", TitoloLibro = libro.Titolo });

        }
    }
}