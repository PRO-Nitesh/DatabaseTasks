using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cacheImplementation.Models
{
    public class Order
    {
        [Key]
        public Guid order_id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid product_id { get; set; }

        [Required]
        [ForeignKey("Customer")]

        public Guid customer_id { get; set; }  
        public int quantity { get; set; }
        public DateTime order_date { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
