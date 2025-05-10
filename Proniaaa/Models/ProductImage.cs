using Proniaaa.Models.Base;

namespace Proniaaa.Models
{
    public class ProductImage:BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool IsPrime { get; set; }
    }
}
