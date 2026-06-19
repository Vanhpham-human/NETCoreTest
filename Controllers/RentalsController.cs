using ComicSystem.Data;
using ComicSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ComicSystem.Controllers;

public class RentalsController : Controller
{
    private readonly ComicSystemContext _context;

    public RentalsController(ComicSystemContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create()
    {
        await LoadSelectLists();
        return View(new RentalCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RentalCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var comicBook = await _context.ComicBooks.FindAsync(model.ComicBookID);
            if (comicBook == null)
            {
                ModelState.AddModelError("", "Truyện tranh không tồn tại.");
            }
            else
            {
                var rental = new Rental
                {
                    CustomerID = model.CustomerID,
                    RentalDate = model.RentalDate,
                    ReturnDate = model.ReturnDate,
                    Status = "Đang thuê"
                };

                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                var detail = new RentalDetail
                {
                    RentalID = rental.RentalID,
                    ComicBookID = model.ComicBookID,
                    Quantity = model.Quantity,
                    PricePerDay = comicBook.PricePerDay
                };

                _context.RentalDetails.Add(detail);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Xử lý thuê truyện thành công!";
                return RedirectToAction(nameof(Create));
            }
        }

        await LoadSelectLists(model.CustomerID, model.ComicBookID);
        return View(model);
    }

    private async Task LoadSelectLists(int? customerId = null, int? comicBookId = null)
    {
        ViewBag.CustomerID = new SelectList(await _context.Customers.ToListAsync(), "CustomerID", "FullName", customerId);
        ViewBag.ComicBookID = new SelectList(await _context.ComicBooks.ToListAsync(), "ComicBookID", "Title", comicBookId);
    }
}
