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
            return Page();
        }
    }
}