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

            //ViewData["LibriHorror"] = Libro.getLibriGenres(connectionString, 1);
            //ViewData["LibriFantascienza"] = Libro.getLibriGenres(connectionString, 2);

            List<Libro> libri = Libro.getLibri(connectionString);
            ViewData["LibriHorror"] = (List<Libro>)(libri.Where(l => l.Genere.IdGenere == 1).ToList());

            Libro LastLibro = Libro.getLastLibro(connectionString);
            ViewData["LastLibro"] = LastLibro;
        }
    }
}
