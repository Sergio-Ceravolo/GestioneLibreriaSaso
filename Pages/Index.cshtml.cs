using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace GestioneLibreriaSaso.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

       

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string connectionString = "Server=217.61.62.212;Database=GestioneLibreria_Saso;User Id=sa;Password=Kundividi@FSD2024;Encrypt=True;TrustServerCertificate=True;";

            ViewData["LibriFantasy"] = Libro.getLibriGenres(connectionString, "Fantasy");
            ViewData["LibriHorror"] = Libro.getLibriGenres(connectionString, "Horror");
            ViewData["LibriFantascienza"] = Libro.getLibriGenres(connectionString, "Fantascienza");

            Libro LastLibro = Libro.getLastLibro(connectionString);
            ViewData["LastLibro"] = LastLibro;
        }
    }
}
