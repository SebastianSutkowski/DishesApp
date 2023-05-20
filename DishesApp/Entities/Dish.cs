using DishesApp.Entities.ManyManyConnectors;

namespace DishesApp.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public int TimeNeaded { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public PreparingMethod PreparingMethod { get; set; }
        public int PreparingMethodId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<ProductDish> ProductDishConnectors { get; set; }


    }
}
