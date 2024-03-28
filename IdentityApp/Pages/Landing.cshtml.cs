using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class LandingModel : PageModel
    {
        public LandingModel(ProductDBContext ctx) => DbContext = ctx;
        public ProductDBContext DbContext { get; set; }
    }
}
