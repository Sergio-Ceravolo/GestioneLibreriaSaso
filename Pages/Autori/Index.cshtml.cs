using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestioneLibreriaSaso.Pages.Autori
{
    public class IndexModel : PageModel
    {
        
        public void OnGet(int? number)
        {
            ViewData["number"] = number + 1;
        }
    }
}
