using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Libri
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Libro Libro { get; set; }

        [BindProperty]
        public IFormFile? ImgCopertina { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet(int? id)
        {
            if (!id.HasValue)
            {
                RedirectToPage("Index");
            }

            List<Autore> ListAutori = new List<Autore>();
            ListAutori = Autore.getAutori(ConnectionString);
            ViewData["ListAutori"] = ListAutori;

            Libro = new Libro();
            Libro.IdLibro = id.Value;
            Libro.getLibro(ConnectionString);
        }

        public IActionResult OnPost()
        {
            List<Autore> ListAutori = new List<Autore>();
            ListAutori = Autore.getAutori(ConnectionString);
            ViewData["ListAutori"] = ListAutori;

            if (!ModelState.IsValid)
            {
                return Page(); // Ricarica la pagina mostrando gli errori
            }

            if (ImgCopertina != null && ImgCopertina.Length > 0)
            {

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
                        TempData["Warning"] = "Qualcosa è andato storto durante il caricamento dell'immagine";
                    }
                }
                Libro.Copertina = fileName;

            }

            try
            {
                Libro.editLibro(ConnectionString);
                TempData["Success"] = $"Libro {Libro.Titolo} modificato correttamente!";
            }
            catch
            {
                TempData["Warning"] = "Qualcosa è andato storto durante la modifica";
            }


            return RedirectToPage("Index");
        }
    }
}