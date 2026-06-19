using ComicSystem.Data;
using ComicSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicSystem.Controllers;

public class CustomersController : Controller
{
    private readonly ComicSystemContext _context;

    public CustomersController(ComicSystemContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View(new Customer { RegistrationDate = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Đăng ký khách hàng thành công!";
            return RedirectToAction(nameof(Register));
        }
        return View(customer);
    }
}
