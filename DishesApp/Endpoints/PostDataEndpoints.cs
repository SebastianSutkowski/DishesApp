using DishesApp.Dto;
using DishesApp.Endpoints.methods;
using DishesApp.Entities;

namespace DishesApp.Endpoints
{
    public static class PostDataEndpoints
    {
        public static void AddDataEndpointsSet(this IEndpointRouteBuilder app)
        {
       
            app.MapPost("/newTag", PostDataEndpoints.PostTag);
            app.MapPost("/newProduct", PostDataEndpoints.PostProduct);
            app.MapPost("/newDish", PostDataEndpoints.PostDish);
        }

        public static async Task<IResult> PostTag(IPostMethods methods, string newTag)
        {
            var result = await methods.AddNewTag(newTag);
            if (result.Result)
            {
                return Results.Ok(result.Message);
            }
            return Results.NotFound(result.Message);
            
        }
        public static async Task<IResult> PostProduct(IPostMethods methods, ProductDto newProductDto)
        {
            var result = await methods.AddNewProduct(newProductDto);
            if (result.Result)
            {
                return Results.Ok(result.Message);
            }
            return Results.NotFound(result.Message);
        }
        public static async Task<IResult> PostDish(IPostMethods methods, NewDishDto newDishDto)
        {
            var result = await methods.AddNewDish(newDishDto);
            if (result.Result)
            {
                return Results.Ok(result.Message);
            }
            return Results.NotFound(result.Message);
        }
    }
}
