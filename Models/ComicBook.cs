using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicSystem.Models;

public class ComicBook
{
    public int ComicBookID { get; set; }

    [Required, StringLength(255)]
    [Display(Name = "Tên truyện")]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(255)]
    [Display(Name = "Tác giả")]
    public string Author { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(10,2)")]
    [Display(Name = "Giá thuê/ngày")]
    public decimal PricePerDay { get; set; }

    public ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
}
