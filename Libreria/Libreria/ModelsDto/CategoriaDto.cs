using Libreria.Entita;


namespace Libreria.ModelsDto
{
    public class CategoriaDto
    {
        public CategoriaDto()
        {
        }

        public CategoriaDto(Categoria categoria)
        {
            Id = categoria.Id_categoria;
            Nome = categoria.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}

