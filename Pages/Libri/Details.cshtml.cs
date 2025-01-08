using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Libri
{
    public class DetailsModel : PageModel
    {
        public Libro Libro { get; set; }

        public string ConnectionString { get; private set; } = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

        public void OnGet(int? id)
        {
            if (!id.HasValue)
            {
                RedirectToPage("Index");
            }

            Libro = new Libro();
            Libro.IdLibro = id.Value;
            Libro.getLibro(ConnectionString);
        }
    }
}
