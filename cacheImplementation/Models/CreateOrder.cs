namespace cacheImplementation.Models
{
    public class CreateOrder
    {
        public Guid customer_id { get; set; }
        public Guid product_id { get; set; }
        public int quantity { get; set; }
    }
}
