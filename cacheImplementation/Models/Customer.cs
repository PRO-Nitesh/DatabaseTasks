using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace cacheImplementation.Models
{
    public class Customer
    {

        public Customer()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

        [Key]
        public Guid customer_id { get; set; }
        [Required]
        public string customer_name { get; set; } = "";
        public string  email { get; set; } = "";
        public string phone { get; set; } = "";
        public string gender { get; set; } = "";
        [Required]
        
        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; } 
    }
}
