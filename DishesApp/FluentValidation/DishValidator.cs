using DishesApp.Entities;
using FluentValidation;

namespace DishesApp.FluentValidation
{
    public class DishValidator : AbstractValidator<Dish>
    {
        public DishValidator()
        {
            RuleFor(d => d.Name).MinimumLength(3).MaximumLength(20);
            RuleFor(d => d.ShortDescription).MinimumLength(5);

        }
    }
}
