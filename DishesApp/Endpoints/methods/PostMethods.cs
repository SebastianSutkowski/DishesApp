using DishesApp.Dto;
using DishesApp.Entities;
using DishesApp.Entities.ManyManyConnectors;
using DishesApp.Exceptions;
using DishesApp.FluentValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DishesApp.Endpoints.methods
{
    public interface IPostMethods
    {
        Task<ActionResult> AddNewTag(string newTagName);
        Task<ActionResult> AddNewProduct(ProductDto productDto);
        Task<ActionResult> AddNewDish(NewDishDto dishDto);

    }
    public class PostMethods : IPostMethods
    {
        private readonly DishesAppDbContext dbContext;
        private readonly IValidator<Tag> tagValidator;
        private readonly IValidator<Product> productValidator;
        private readonly IValidator<Dish> dishValidator;

        public PostMethods(DishesAppDbContext dbContext, 
            IValidator<Tag> tagValidator, 
            IValidator<Product> productValidator,
            IValidator<Dish> dishValidator)
        {
            this.dbContext = dbContext;
            this.tagValidator = tagValidator;
            this.productValidator = productValidator;
            this.dishValidator = dishValidator;
        }
        public async Task<ActionResult> AddNewTag(string newTagName)
        {
            var newTag = new Tag { 
                Name = newTagName
            };
            var methodResult = new ActionResult();
            var result = await tagValidator.ValidateAsync(newTag);
            if (!result.IsValid)
            {
                methodResult.Result = false;
                methodResult.Message = String.Join(", ", result.Errors);
                return methodResult;
            }
           
            var isInDb = await dbContext.Tags.AnyAsync(t => t.Name.ToLower() == newTagName.ToLower());
            if (isInDb)
            {
                methodResult.Result = false;
                methodResult.Message = "Tag with this name already exists";
                return methodResult;
            }
            dbContext.Tags.Add(newTag);
            await dbContext.SaveChangesAsync();
            methodResult.Result = true;
            methodResult.Message = $"new tag with name {newTag.Name} added";
            return methodResult;
        }
        public async Task<ActionResult> AddNewProduct(ProductDto productDto)
        {
            var methodResult = new ActionResult();
            var measurmentUnit = await dbContext.MeasurmentUnits.FirstOrDefaultAsync(mu => mu.Id == productDto.MeasurmentUnitId);
            if(measurmentUnit == null)
            {
                throw new NotFoundException($"measurment Unit with id {productDto.MeasurmentUnitId} does not exist");
            }
            var newProduct = new Product
            {
                Name = productDto.Name
            };
            var result = await productValidator.ValidateAsync(newProduct);
            if (!result.IsValid)
            {
                methodResult.Result = false;
                methodResult.Message = String.Join(", ", result.Errors);
                return methodResult;
            }
            var isInDb = await dbContext.Products.AnyAsync(p => p.Name.ToLower() == productDto.Name.ToLower());
            if (isInDb)
            {
                methodResult.Result = false;
                methodResult.Message = "Product with this name already exists";
                return methodResult;
            }
            measurmentUnit.Products.Add(newProduct);
            dbContext.MeasurmentUnits.Update(measurmentUnit);
            await dbContext.SaveChangesAsync();
            methodResult.Result = true;
            methodResult.Message = $"new product with name {productDto.Name} added";
            return methodResult;

        }
        public async Task<ActionResult> AddNewDish(NewDishDto dishDto)
        {
            var methodResult = new ActionResult();
            var tagIds = dishDto.TagsIds.ToList();
            var productsQuantityObj = dishDto.ProductsQuantityList.ToList();
            List<int> productsIds = new List<int>();
           
            foreach (var productQuantity in productsQuantityObj)
            {
                productsIds.Add(productQuantity.ProductId);
                

            }
            
            var products = await dbContext.Products.Where(p => productsIds.Contains(p.Id)).ToListAsync();
            if (products == null)
            {
                throw new NotFoundException($"there isn't products with given IDs");
            }
            var tags = await dbContext.Tags.Where(t => tagIds.Contains(t.Id)).ToListAsync();
            var preparingMethod = await dbContext.PreparingMethods.FirstOrDefaultAsync(pm => pm.Id == dishDto.PreparingMethodId);
            if (preparingMethod == null)
            {
                throw new NotFoundException($"there isn't preparing method with given ID");
            }
            var recipe = new Recipe { Prescription = dishDto.Recipe };
            


            var newDish = new Dish
            {
                Name = dishDto.Name,
                PhotoUrl = dishDto.PhotoUrl,
                ShortDescription = dishDto.ShortDescription,
                TimeNeaded = dishDto.TimeNeeded,
                Recipe = recipe,
                PreparingMethod = preparingMethod,
                Tags = tags,
                Products=products
                
            };
            var newConnectorsWithData = new List<ProductDish>();
            foreach(var productQuantity in productsQuantityObj)
            {
                
                var pdConnector = new ProductDish
                {
                  
                   ProductId = productQuantity.ProductId,
                    Quantity = productQuantity.Quantity,


                };
                newConnectorsWithData.Add(pdConnector);


            }
            newDish.ProductDishConnectors=newConnectorsWithData;

            var isInDb = await dbContext.Dishes.AnyAsync(p => p.Name.ToLower() == newDish.Name.ToLower());
            if (isInDb)
            {
                methodResult.Result = false;
                methodResult.Message = "Dish with this name already exists";
                return methodResult;
            }
            var result = await dishValidator.ValidateAsync(newDish);
            if (!result.IsValid)
            {
                methodResult.Result = false;
                methodResult.Message = String.Join(", ", result.Errors);
                return methodResult;
            }
            //await dbContext.Recipes.AddAsync(recipe);
            //await dbContext.SaveChangesAsync();
            
            await dbContext.Dishes.AddAsync(newDish);
            await dbContext.SaveChangesAsync();
            var recipeSaved = await dbContext.Recipes.FirstOrDefaultAsync(r => r.Equals(recipe));
            var dishSaved = await dbContext.Dishes.FirstOrDefaultAsync(d=>d.Equals(newDish));
            dishSaved.RecipeId = recipeSaved.Id;
            dbContext.Dishes.Update(dishSaved);
            await dbContext.SaveChangesAsync();

            methodResult.Result = true;
            methodResult.Message = $"new dish with name {newDish.Name} added";
            return methodResult;
        }
    }

    
}
