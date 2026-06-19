using System.ComponentModel.DataAnnotations;

namespace ComicSystem.Models;

public class RentalCreateViewModel
{
    [Required]
    [Display(Name = "Khách hàng")]
    public int CustomerID { get; set; }

    [Required]
    [Display(Name = "Truyện tranh")]
    public int ComicBookID { get; set; }

    [Required, DataType(DataType.Date)]
    [Display(Name = "Ngày thuê")]
    public DateTime RentalDate { get; set; } = DateTime.Today;

    [Required, DataType(DataType.Date)]
    [Display(Name = "Ngày trả")]
    public DateTime ReturnDate { get; set; } = DateTime.Today.AddDays(7);

    [Required, Range(1, int.MaxValue)]
    [Display(Name = "Số lượng")]
    public int Quantity { get; set; } = 1;
}
