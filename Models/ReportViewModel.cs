using System.ComponentModel.DataAnnotations;

namespace ComicSystem.Models;

public class ReportViewModel
{
    [Required, DataType(DataType.Date)]
    [Display(Name = "Từ ngày")]
    public DateTime StartDate { get; set; } = new DateTime(2024, 10, 1);

    [Required, DataType(DataType.Date)]
    [Display(Name = "Đến ngày")]
    public DateTime EndDate { get; set; } = new DateTime(2024, 10, 31);

    public List<ReportItemViewModel> Items { get; set; } = new();
}

public class ReportItemViewModel
{
    public int No { get; set; }
    public string BookName { get; set; } = string.Empty;
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
