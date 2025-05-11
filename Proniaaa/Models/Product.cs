using Proniaaa.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proniaaa.Models
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public List<ProductImage>? Images { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile? file { get; set; }
    }
}
