using DishesApp.Entities;

namespace DishesApp.Dto
{
    public class DishGetDto
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ShortDescription { get; set; }
        public int TimeNeaded { get; set; }
        public string PreparingMethod { get; set; }
        public List<ProductGetDto> Products { get; set; } = new List<ProductGetDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
