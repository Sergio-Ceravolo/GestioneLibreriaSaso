using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace GestioneLibreriaSaso.Pages.Libri
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Libro Libro { get; set; }

        [BindProperty]
        public IFormFile? ImgCopertina { get; set; }

        public string Messaggio { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";



        public void OnGet()
        {
            List<Autore> ListAutori = new List<Autore>();
            ListAutori = Autore.getAutori(ConnectionString);
            ViewData["ListAutori"] = ListAutori;
        }



        public IActionResult OnPost()
        {
                Libro.Autore.IdAutore = 0;
            

            if (!ModelState.IsValid)
            {
                return Page(); // Ricarica la pagina mostrando gli errori
            }

            if (ImgCopertina == null || ImgCopertina.Length == 0)
            {
                Messaggio = "Nessun file selezionato.";
                return Page(); // Ricarica la pagina mostrando gli errori
            }
            //string fileName = Path.GetFileName(ImgCopertina.FileName);
            string fileName = Guid.NewGuid() + Path.GetExtension(ImgCopertina.FileName);
            string percorso = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/dist/img/copertine",
                fileName
            );
            using (var stream = new FileStream(percorso, FileMode.Create))
            {
                try
                {
                    ImgCopertina.CopyTo(stream);
                }
                catch
                {
                    Messaggio = "Qualcosa � andato storto durante il caricamento dell'immagine";
                }
            }
            Libro.Copertina = fileName;

            

            try
            {
                Libro.createLibro(ConnectionString);
                Messaggio = $"Libro {Libro.Titolo} caricato correttamente!";
            }
            catch
            {
                Messaggio = "Qualcosa � andato storto durante l'inserimento";
            }

            return RedirectToPage("Index");
        }
    }
}
