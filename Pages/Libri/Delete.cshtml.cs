using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GestioneLibreriaSaso.Pages.Libri
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Rimuovi { get; set; }

        [BindProperty]
        public int? Id { get; set; }

        public string? Title { get; set; }

        public string Messaggio { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet(int? id, string title)
        {
            if (!id.HasValue || string.IsNullOrEmpty(title))
            {
                RedirectToPage("Index");
            }

            Id = id.Value;
            Title = title;
        }

        public IActionResult OnPost()
        {
            if (Rimuovi == 1)
            {
                Libro Libro1 = new Libro();
                Libro1.IdLibro = Id.Value;
                Libro1.deleteLibro(ConnectionString);
                TempData["Success"] = $"Libro eliminato con successo!";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["Warning"] = "Nessun libro eliminato!";
                return RedirectToPage("Index");
            }
        }
    }
}
