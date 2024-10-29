using Libreria.Entita;

namespace Libreria.Request
{
    public class CreateCategoriaRequest
    {
        public string Nome { get; set; } = string.Empty;

        public Categoria ToEntity()
        {
            var categoria = new Categoria();
            categoria.Nome = Nome;
            return categoria;
        }
    }

}
