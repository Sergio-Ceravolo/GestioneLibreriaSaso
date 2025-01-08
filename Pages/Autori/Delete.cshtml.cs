using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Rimuovi { get; set; }

        [BindProperty]
        public int? Id { get; set; }

        public string? NomeCognome { get; set; }

        public string Messaggio { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet(int? id, string nomeCognome)
        {
            if (!id.HasValue || string.IsNullOrEmpty(nomeCognome))
            {
                RedirectToPage("Index");
            }

            Id = id.Value;
            NomeCognome = nomeCognome;
        }

        public IActionResult OnPost()
        {
            if (Rimuovi == 1)
            {
                Autore Autore1 = new Autore();
                Autore1.IdAutore = Id.Value;
                Autore1.deleteAutore(ConnectionString);
                TempData["Success"] = "Autore eliminato con successo!";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["Warning"] = "Nessun autore eliminato!";
                return RedirectToPage("Index");
            }
        }
    }
}
