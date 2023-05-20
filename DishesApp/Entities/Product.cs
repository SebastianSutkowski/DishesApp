using DishesApp.Entities.ManyManyConnectors;

namespace DishesApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasurmentUnit MeasurmentUnit { get; set; }
        public int MeasurmentUnitId { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public ICollection<ProductDish> ProductDishConnectors { get; set; }
    }
}
