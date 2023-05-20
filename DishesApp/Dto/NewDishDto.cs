namespace DishesApp.Dto
{
    public class NewDishDto
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public int TimeNeeded { get; set; }
        public string Recipe { get; set; }
        public int PreparingMethodId { get; set; }
        public List<ProductDishQuantity> ProductsQuantityList { get; set; }
        public List<int> TagsIds { get; set; }
    }
}
