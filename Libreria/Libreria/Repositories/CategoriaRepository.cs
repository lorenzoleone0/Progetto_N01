using Libreria.Database;
using Libreria.Entita;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Libreria.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext context) : base(context)
        {
        }

  

    }
}

