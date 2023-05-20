namespace DishesApp.Entities.ManyManyConnectors
{
    public class ProductDish
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}
