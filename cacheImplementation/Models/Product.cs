using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace cacheImplementation.Models
{
    public class Product
    {


        public Product()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
        [Key]
        public Guid product_id { get; set; }
        public string name { get; set; } = "";
        public int quantity { get; set; }
        public string description { get; set; } = "";
        public decimal unit_price { get; set; }
        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; } 
    }
}
