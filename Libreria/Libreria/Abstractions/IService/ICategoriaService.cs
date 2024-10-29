using Libreria.Entita;
using Libreria.Request;


namespace Libreria.Abstractions.IService
{
    public interface ICategoriaService
    {
        Task<Categoria?> GetCategoriaByIdAsync(int id);
        Task<Categoria> AggiungiCategoriaAsync(Categoria categoria);
        Task EliminaCategoriaAsync(int id);
        bool EsisteNomeCategoria(string nome);
    }
}

