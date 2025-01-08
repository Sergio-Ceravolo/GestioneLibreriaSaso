using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Autore Autore { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet(int? id)
        {
            if (!id.HasValue)
            {
                RedirectToPage("Index");
            }

            Autore = new Autore();
            Autore.IdAutore = id.Value;
            Autore.getAutore(ConnectionString);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Ricarica la pagina mostrando gli errori
            }



            try
            {
                Autore.editAutore(ConnectionString);
                TempData["Success"] = $"Autore {Autore.NomeCognome} modificato correttamente!";
            }
            catch
            {
                TempData["Warning"] = "Qualcosa è andato storto durante la modifica";
            }


            return RedirectToPage("Index");
        }
    }
}
