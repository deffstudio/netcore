using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers;

public class StoreController : Controller
{
    private ProductDBContext DBContext;
    public StoreController(ProductDBContext ctx) => DBContext = ctx;
    public IActionResult Index() => View(DBContext.Products);
}
