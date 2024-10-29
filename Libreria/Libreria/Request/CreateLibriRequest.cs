using Libreria.Database;
using Libreria.Entita;

namespace Libreria.Request
{
    public class CreateLibroRequest
    {
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;
        public List<string> Categorie { get; set; } = new List<string>();

        public Libro ToEntity()
        {
            var libro = new Libro
            {
                Titolo = Titolo,
                Autore = Autore,
                DataPubblicazione = DataPubblicazione,
                Editore = Editore,
                Categorie = string.Join(",", Categorie)
            };
            return libro;
        }
    }
}
