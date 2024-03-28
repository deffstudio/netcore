using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.Controllers;

[Authorize]
public class StoreController : Controller
{
    private ProductDBContext DBContext;
    public StoreController(ProductDBContext ctx) => DBContext = ctx;
    public IActionResult Index() => View(DBContext.Products);
}
