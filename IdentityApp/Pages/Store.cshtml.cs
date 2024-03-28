using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityApp.Models;

namespace IdentityApp.Pages
{
    public class StoreModel : PageModel
    {
        public ProductDBContext DbContext { get; set; }

        public StoreModel(ProductDBContext ctx) => DbContext = ctx;

    }
}
