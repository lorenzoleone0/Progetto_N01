using FluentValidation;
using Libreria.Abstractions.IService;
using Libreria.Request;

namespace Libreria.Validatori
{
    public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
    {
        private readonly ICategoriaService _categoriaService;
        public CreateCategoriaRequestValidator(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;

            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage("Il nome della categoria è obbligatorio.")
               .Must(nome => !_categoriaService.EsisteNomeCategoria(nome)) 
               .WithMessage("Il nome della categoria esiste già");
        }
    }
}
