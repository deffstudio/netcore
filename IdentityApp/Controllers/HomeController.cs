using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers;

public class HomeController : Controller
{
    private ProductDBContext DBContext;
    public HomeController(ProductDBContext ctx) => DBContext = ctx;
    public IActionResult Index() => View(DBContext.Products);
}
