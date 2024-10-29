using Libreria.Entita;

namespace Libreria.Request
{
    public class ModificaLibroRequest
    {
        public int Id { get; set; } 

        public string Titolo { get; set; } = string.Empty; 

        public string Autore { get; set; } = string.Empty; 

        public DateTime DataPubblicazione { get; set; } 

        public string Editore { get; set; } = string.Empty;

        public List<string> Categorie { get; set; } = new List<string>();

    }
}
