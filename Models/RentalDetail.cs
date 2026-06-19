using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicSystem.Models;

public class RentalDetail
{
    public int RentalDetailID { get; set; }

    [Required]
    public int RentalID { get; set; }

    [Required]
    [Display(Name = "Truyện tranh")]
    public int ComicBookID { get; set; }

    [Required, Range(1, int.MaxValue)]
    [Display(Name = "Số lượng")]
    public int Quantity { get; set; }

    [Required, Column(TypeName = "decimal(10,2)")]
    [Display(Name = "Giá thuê/ngày")]
    public decimal PricePerDay { get; set; }

    public Rental? Rental { get; set; }
    public ComicBook? ComicBook { get; set; }
}
