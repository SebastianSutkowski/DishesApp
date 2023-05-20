using DishesApp.Entities.ManyManyConnectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DishesApp.Entities.Configurations
{
    public class ProductDishConnectorConfiguration : IEntityTypeConfiguration<ProductDish>
    {
        public void Configure(EntityTypeBuilder<ProductDish> pd)
        {
            pd.HasKey(pd => new { pd.ProductId, pd.DishId });
            pd.HasOne(pd => pd.Product)
                .WithMany(p => p.ProductDishConnectors)
                .HasForeignKey(pd => pd.ProductId);
            pd.HasOne(pd => pd.Dish)
                .WithMany(p => p.ProductDishConnectors)
                .HasForeignKey(pd => pd.DishId);
        }
    }
}
