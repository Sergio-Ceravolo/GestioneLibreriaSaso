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

            List<Libro> ListLibri = new List<Libro>();
            ListLibri = Libro.getLibriGenres(connectionString, "Fantasy");
            ViewData["LibriFantasy"] = ListLibri;
            
            Libro LastLibro = Libro.getLastLibro(connectionString);
            ViewData["LastLibro"] = LastLibro;
        }
    }
}
