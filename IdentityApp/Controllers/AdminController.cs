﻿using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers;

public class AdminController : Controller
{
    private ProductDBContext DbContext;
    public AdminController(ProductDBContext ctx) => DbContext = ctx;

    public IActionResult Index() => View(DbContext.Products);

    [HttpGet]
    public IActionResult Create() => View("Edit", new Product());
    [HttpGet]
    public IActionResult Edit(long id)
    {
        Product? p = DbContext.Find<Product>(id);
        if (p != null)
        {
            return View("Edit", p);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Save(Product p)
    {
        DbContext.Update(p);
        DbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(long id)
    {
        Product? p = DbContext.Find<Product>(id);
        if (p != null)
        {
            DbContext.Remove(p);
            DbContext.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}