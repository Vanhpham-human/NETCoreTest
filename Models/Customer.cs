using System.ComponentModel.DataAnnotations;

namespace ComicSystem.Models;

public class Customer
{
    public int CustomerID { get; set; }

    [Required, StringLength(255)]
    [Display(Name = "Họ tên")]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(15)]
    [Display(Name = "Số điện thoại")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required, DataType(DataType.Date)]
    [Display(Name = "Ngày đăng ký")]
    public DateTime RegistrationDate { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
