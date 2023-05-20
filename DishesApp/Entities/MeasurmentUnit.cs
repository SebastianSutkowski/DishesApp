namespace DishesApp.Entities
{
    public class MeasurmentUnit
    {
        public int Id { get; set; }
        public string description { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
