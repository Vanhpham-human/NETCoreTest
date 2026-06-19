using ComicSystem.Data;
using ComicSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicSystem.Controllers;

public class ReportsController : Controller
{
    private readonly ComicSystemContext _context;

    public ReportsController(ComicSystemContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(new ReportViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(ReportViewModel model)
    {
        if (ModelState.IsValid)
        {
            var items = await _context.RentalDetails
                .Include(rd => rd.Rental)
                    .ThenInclude(r => r!.Customer)
                .Include(rd => rd.ComicBook)
                .Where(rd => rd.Rental!.RentalDate >= model.StartDate
                          && rd.Rental.RentalDate <= model.EndDate)
                .OrderBy(rd => rd.Rental!.RentalDate)
                .Select(rd => new ReportItemViewModel
                {
                    BookName = rd.ComicBook!.Title,
                    RentalDate = rd.Rental!.RentalDate,
                    ReturnDate = rd.Rental.ReturnDate,
                    CustomerName = rd.Rental.Customer!.FullName,
                    Quantity = rd.Quantity
                })
                .ToListAsync();

            for (var i = 0; i < items.Count; i++)
            {
                items[i].No = i + 1;
            }

            model.Items = items;
        }

        return View(model);
    }
}
