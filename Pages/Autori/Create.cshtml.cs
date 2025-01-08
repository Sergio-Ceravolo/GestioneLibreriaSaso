using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Autore Autore { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Ricarica la pagina mostrando gli errori
            }

            try
            {
                Autore.createAutore(ConnectionString);
                TempData["Success"] = $"Autore {Autore.NomeCognome} caricato correttamente!";
            }
            catch
            {
                TempData["Warning"] = "Qualcosa è andato storto durante l'inserimento";
            }

            return RedirectToPage("Index");
        }
    }
}
