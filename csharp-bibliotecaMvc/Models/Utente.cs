using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace csharp_bibliotecaMvc.Models
{
    public class Utente
    {
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
    }
}
