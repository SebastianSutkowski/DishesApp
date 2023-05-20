using DishesApp.Entities.ManyManyConnectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DishesApp.Entities.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> d)
        {
            d.HasOne(d => d.Recipe)
                .WithOne(d => d.Dish)
                .HasForeignKey<Recipe>(r => r.DishId);
            d.HasOne(d => d.PreparingMethod)
                .WithMany(d => d.Dishes)
                .HasForeignKey(p => p.PreparingMethodId);
            d.HasMany(d=>d.Products)
                .WithMany(p=>p.Dishes)
                .UsingEntity<ProductDish>(
                pd => pd.HasOne(pdc => pdc.Product)
                .WithMany()
                .HasForeignKey(pdc=>pdc.ProductId),

                pd =>pd.HasOne(pdc=>pdc.Dish)
                .WithMany()
                .HasForeignKey(pdc=>pdc.DishId),
                pdc =>
                {
                    pdc.HasKey(x => new { x.DishId, x.ProductId });
                });
            d.HasMany(di => di.Tags)
                .WithMany(t => t.Dishes)
                .UsingEntity<TagDish>(
                td => td.HasOne(tdd => tdd.Tag)
                .WithMany()
                .HasForeignKey(tdd => tdd.TagId),
                td => td.HasOne(tdd => tdd.Dish)
                .WithMany()
                .HasForeignKey(tdd => tdd.DishId),
                tdd =>
                {
                    tdd.HasKey(x => new { x.DishId, x.TagId });
                });
            d.Property(x => x.Name).IsRequired().HasMaxLength(30);
            d.Property(x => x.ShortDescription).IsRequired().HasMaxLength(300);
            d.Property(x => x.TimeNeaded).IsRequired();
            d.Property(x => x.RecipeId).IsRequired();



        }
    }
}
