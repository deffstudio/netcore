using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.Pages
{
    [Authorize]
    public class StoreModel : PageModel
    {
        public ProductDBContext DbContext { get; set; }

        public StoreModel(ProductDBContext ctx) => DbContext = ctx;

    }
}
