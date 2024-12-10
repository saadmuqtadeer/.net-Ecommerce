namespace ProductApi.Model
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int price {  get; set; }
    }
}
