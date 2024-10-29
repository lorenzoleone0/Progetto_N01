
using Azure.Core;
using Libreria.Abstractions.IService;
using Libreria.Entita;
using Libreria.Repositories;
using Libreria.Request;

namespace Libreria.Abstractions.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> AggiungiCategoriaAsync(Categoria categoria)
        {
            var request = new Categoria { Nome = categoria.Nome };
            await _categoriaRepository.AggiungiAsync(categoria); 
            await _categoriaRepository.SalvaAsync(); 
            return request;
        }
        public async Task<Categoria?> GetCategoriaByIdAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }


        public async Task EliminaCategoriaAsync(int id)
        {
            await _categoriaRepository.EliminaAsync(id);
            await _categoriaRepository.SalvaAsync();
        }


        public bool EsisteNomeCategoria(string nome)
        {
            return _categoriaRepository.EsisteNomeCategoria(nome);
        }

    }
}
