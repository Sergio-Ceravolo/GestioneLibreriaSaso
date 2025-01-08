using GestioneLibreriaSaso.Classi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Autore Autore { get; set; }

        public void OnGet()
        {
        }
    }
}
