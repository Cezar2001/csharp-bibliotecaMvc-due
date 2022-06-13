using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_bibliotecaMvc.Models
{
    public enum StatoLibro
    {
        Disponibile, Indisponibile
    }

    public class Libro
    {
        public int LibroID { get; set; }
        public string Titolo { get; set; }
        public int Scaffale { get; set; }
        public StatoLibro Stato { get; set; } 
        public ICollection<Prestito>? Prestiti { get; set; }
        public List<Autore>? Autori { get; set; }
    }
}
