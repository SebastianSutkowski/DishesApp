using DishesApp.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DishesApp.FluentValidation
{
    public class TagValidator : AbstractValidator<Tag>
    {
        private readonly DishesAppDbContext dbContext;

        public TagValidator(DishesAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            RuleFor(t => t.Name).NotEmpty().WithMessage("Tag Name could not be empty");

        }
    }
}
