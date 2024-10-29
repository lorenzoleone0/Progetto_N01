
using Libreria.Entita;


namespace Libreria.Abstractions.IService
{
    public interface ILibroService
    {
        Task<Libro?> GetLibroByIdAsync(int id);
        List<Libro> GetLibri(int pageNumber, int pageSize, string? autore, out int totalNum);
        Task ModificaLibroAsync(Libro libro);
        Task EliminaLibroAsync(int id);
        Task AggiungiLibroAsync(Libro libro);
    }
}

