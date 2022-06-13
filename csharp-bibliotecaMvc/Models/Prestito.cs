using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_bibliotecaMvc.Models
{
    [Table("Prestito")]
    public class Prestito
    {
        public int PrestitoID { get; set; }
        public int LibroID { get; set; }
        public int UtenteID { get; set; }
        public StatoLibro Stato { get; set; }
        public Libro Libro { get; set; }
        public Utente Utente { get; set; }
        public DateTime PrestitoDate { get; set; }
        //public ICollection<Prestito> Prestiti { get; set; }
    }
}
