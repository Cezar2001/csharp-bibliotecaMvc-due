using csharp_bibliotecaMvc.Models;
using System;
using System.Linq;

namespace csharp_bibliotecaMvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BibliotecaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Utenti.Any())
            {
                return;   // DB has been seeded
            }

            var Utenti = new Utente[]
            {
            new Utente{Nome="Carson",Cognome="Alexander"},
            new Utente{Nome="Meredith",Cognome="Alonso"},
            new Utente{Nome="Arturo",Cognome="Anand"},
            new Utente{Nome="Gytis",Cognome="Barzdukas"},
            new Utente{Nome="Yan",Cognome="Li"},
            new Utente{Nome="Peggy",Cognome="Justice"},
            new Utente{Nome="Laura",Cognome="Norman"},
            new Utente{Nome="Nino",Cognome="Olivetto"}
            };
            foreach (Utente u in Utenti)
            {
                context.Utenti.Add(u);
            }
            context.SaveChanges();

            var Autori = new Autore[]
            {
                new Autore{Nome = "Manzoni", Cognome = "Manzoni" },
                new Autore{Nome = "Dante", Cognome = "Alinghieri"}
            };
            foreach (Autore a in Autori)
            {
                context.Autori.Add(a);
            }
            context.SaveChanges();

            var Manzoni = context.Autori.Where(item => item.Nome == "Manzoni").First(); 
            var Dante = context.Autori.Where(item => item.Nome == "Dante").First(); 


            //var Manzoni = context.Autori.Where(item => item.Cognome == "Manzoni").First();
            //var Sciascia = context.Autori.Where(item => item.Cognome == "Sciascia").First();
            //var Follet = context.Autori.Where(item => item.Cognome == "Follet").First();
            //var Doyle = context.Autori.Where(item => item.Cognome == "Doyle").First();
            //var King = context.Autori.Where(item => item.Cognome == "King").First();
            //var Hamingway = context.Autori.Where(item => item.Cognome == "Hamingway").First();
            //var Brown = context.Autori.Where(item => item.Cognome == "Brown").First();


            var Libri = new Libro[]
            {
            new Libro{Titolo="Chemistry",Scaffale=3,Autori = new List<Autore>{Manzoni},Stato=StatoLibro.Disponibile},
            new Libro{Titolo="Microeconomics",Scaffale=3,Autori = new List<Autore>{Dante},Stato=StatoLibro.Indisponibile},
            new Libro{Titolo="Macroeconomics",Scaffale=3,Autori = new List<Autore>{Manzoni},Stato=StatoLibro.Disponibile},
            new Libro{Titolo="Calculus",Scaffale=4,Autori = new List<Autore>{Manzoni},Stato=StatoLibro.Indisponibile},
            new Libro{Titolo="Trigonometry",Scaffale=4,Autori = new List<Autore>{Dante},Stato=StatoLibro.Indisponibile},
            new Libro{Titolo="Composition",Scaffale=3,Autori = new List<Autore>{Dante},Stato=StatoLibro.Disponibile},
            new Libro{Titolo="Literature",Scaffale=4,Autori = new List<Autore>{Manzoni},Stato=StatoLibro.Disponibile}
            };
            foreach (Libro l in Libri)
            {
                context.Libri.Add(l);
            }
            context.SaveChanges();

            var Prestiti = new Prestito[]
            {
            new Prestito{UtenteID=1,LibroID=1,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2021-06-13")},
            new Prestito{UtenteID=1,LibroID=2,Stato=StatoLibro.Indisponibile,PrestitoDate = DateTime.Parse("2021-08-22")},
            new Prestito{UtenteID=1,LibroID=3,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2021-05-02")},
            new Prestito{UtenteID=2,LibroID=4,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2021-02-02")},
            new Prestito{UtenteID=2,LibroID=5,Stato=StatoLibro.Indisponibile,PrestitoDate = DateTime.Parse("2021-03-08")},
            new Prestito{UtenteID=2,LibroID=6,Stato=StatoLibro.Indisponibile,PrestitoDate = DateTime.Parse("2021-09-11")},
            new Prestito{UtenteID=3,LibroID=4,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2021-01-05")},
            new Prestito{UtenteID=4,LibroID=2,Stato=StatoLibro.Indisponibile,PrestitoDate = DateTime.Parse("2021-07-15")},
            new Prestito{UtenteID=4,LibroID=1,Stato=StatoLibro.Indisponibile,PrestitoDate = DateTime.Parse("2021-12-10")},
            new Prestito{UtenteID=5,LibroID=2,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2022-03-9")},
            new Prestito{UtenteID=6,LibroID=3,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2022-04-22")},
            new Prestito{UtenteID=7,LibroID=5,Stato=StatoLibro.Disponibile,PrestitoDate = DateTime.Parse("2021-05-17")},
            };
            foreach (Prestito p in Prestiti)
            {
                context.Prestiti.Add(p);
            }
            context.SaveChanges();
        }
    }
}
