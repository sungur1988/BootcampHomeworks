using System.ComponentModel.DataAnnotations;

namespace Teleperformance.WebAPI.Models
{
    public class ProductUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
