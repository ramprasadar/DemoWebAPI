using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage="Required")]
        public int Qty { get; set; }

        [Required(ErrorMessage ="Required")]
        public int Price { get; set; }
    }
}
