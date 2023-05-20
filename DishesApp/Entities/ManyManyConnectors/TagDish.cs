namespace DishesApp.Entities.ManyManyConnectors
{
    public class TagDish
    {
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
    }
}
