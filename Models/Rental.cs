using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicSystem.Models;

public class Rental
{
    public int RentalID { get; set; }

    [Required]
    [Display(Name = "Khách hàng")]
    public int CustomerID { get; set; }

    [Required, DataType(DataType.Date)]
    [Display(Name = "Ngày thuê")]
    public DateTime RentalDate { get; set; }

    [Required, DataType(DataType.Date)]
    [Display(Name = "Ngày trả")]
    public DateTime ReturnDate { get; set; }

    [Required, StringLength(50)]
    [Display(Name = "Trạng thái")]
    public string Status { get; set; } = "Đang thuê";

    public Customer? Customer { get; set; }
    public ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
}
