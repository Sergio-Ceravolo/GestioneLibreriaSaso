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
        public IFormFile File { get; set; }

        public string Messaggio { get; set; }


        public void OnGet()
        {
        }


        public void OnPost()
        {
            if (File == null || File.Length == 0)
            {
                Messaggio = "Nessun file selezionato.";
                return;
            }
            //string fileName = Path.GetFileName(File.FileName);
            string fileName = Path.GetExtension(File.FileName);
            string percorso = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/dist/img/uploads",
                fileName
            );
            using (var stream = new FileStream(percorso, FileMode.Create))
            {
                File.CopyTo(stream);
            }
            Libro.Copertina = fileName;
            Messaggio = $"Libro {Libro.Titolo} caricato con immagine {fileName}!";
        }
    }
}
