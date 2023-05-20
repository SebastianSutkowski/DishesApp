using DishesApp.Entities;
using FluentValidation;

namespace DishesApp.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3).MaximumLength(20).WithMessage("Product Name could not be empty and length must be between 3-20 characters");
        }
    }
}
