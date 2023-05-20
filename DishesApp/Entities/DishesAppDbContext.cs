using DishesApp.Entities.ManyManyConnectors;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;

namespace DishesApp.Entities
{
    public class DishesAppDbContext : DbContext
{
        public DishesAppDbContext(DbContextOptions<DishesAppDbContext> options):base(options)
        {
            
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<MeasurmentUnit> MeasurmentUnits { get; set; }
        public DbSet<PreparingMethod> PreparingMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductDish> ProductDishConnectors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
/*            modelBuilder.Entity<PreparingMethod>().HasData(
                new PreparingMethod{Name = "smażone"},
                new PreparingMethod{Name = "pieczone"},
                new PreparingMethod{Name = "gotowane"},
                new PreparingMethod{Name = "na zimno"}
                );
            modelBuilder.Entity<MeasurmentUnit>().HasData(
                new MeasurmentUnit { description = "ml"},
                new MeasurmentUnit { description = "l"},
                new MeasurmentUnit { description = "łyżeczka"},
                new MeasurmentUnit { description = "łyżka"},
                new MeasurmentUnit { description = "szklanka"},
                new MeasurmentUnit { description = "g"},
                new MeasurmentUnit { description = "kg"}
                );*/
        }
    }
    

}
