using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
            string connectionString = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

            List<Autore> allAutori = new List<Autore>();
            allAutori = Autore.getAutori(connectionString);
            ViewData["allAutori"] = allAutori;
        }
    }
}
