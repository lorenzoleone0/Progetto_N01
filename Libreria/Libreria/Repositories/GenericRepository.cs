using Libreria.Database;
using Libreria.Entita;
using Microsoft.EntityFrameworkCore;


namespace Libreria.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;

        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AggiungiAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
        }

        
        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }
        
        public async Task EliminaAsync(object id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _ctx.Entry(entity).State = EntityState.Deleted;
            }
        }

        public async Task SalvaAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<Utente?> GetByEmailAsync(string email)
        {
            return await _ctx.Utenti.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Utente?> GetByEmailUtenteAsync(string email)
        {
            return await _ctx.Utenti.FirstOrDefaultAsync(u => u.Email == email);
        }

        public bool EsisteNomeCategoria(string nome)
        {
            return _ctx.Set<Categoria>().Any(c => c.Nome.ToLower() == nome.ToLower());
        }
    }
}

