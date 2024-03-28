using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Pages
{
    public class AdminModel : PageModel
    {
        public AdminModel(ProductDBContext ctx) => DbContext = ctx;
        public ProductDBContext DbContext { get; set; }

        public IActionResult OnPost(long id){
            Product p = DbContext.Find<Product>(id);
            if (p != null)
            {
                DbContext.Remove(p);
                DbContext.SaveChanges();
            }
            return Page();
        }
    }
}
