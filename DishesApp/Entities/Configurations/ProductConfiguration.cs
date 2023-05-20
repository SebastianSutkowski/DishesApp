using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DishesApp.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> p)
        {
            p.HasOne(pr => pr.MeasurmentUnit)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.MeasurmentUnitId);


            p.Property(x => x.Name).IsRequired().HasMaxLength(20);
            p.Property(x => x.MeasurmentUnitId).IsRequired();
        }
    }
}
