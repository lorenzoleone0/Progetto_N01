using Libreria.Database;
using Libreria.Entita;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Libreria.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public LibroRepository(MyDbContext context) : base(context)
        {
        }

        public List<Libro> GetLibri(int pageNumber, int pageSize, string? autore, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();

            if (!string.IsNullOrEmpty(autore))
            {
                query = query.Where(b => b.Autore.ToLower().Contains(autore.ToLower()));
            }

            totalNum = query.Count();

            
            return query
                .OrderBy(b => b.Autore)
                .Skip((pageNumber - 1) * pageSize)  
                .Take(pageSize)                     
                .ToList();
        }


    }
}
