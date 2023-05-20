using DishesApp.Endpoints.methods;

namespace DishesApp.Endpoints
{
    public static class GetDataEndpoints
    {
        public static void GetDataEndpointsSet(this IEndpointRouteBuilder app)
        {
            app.MapGet("/get/prepMethods", GetDataEndpoints.prepMethods);
            app.MapGet("/get/tags", GetDataEndpoints.getTags);
            app.MapGet("/get/products", GetDataEndpoints.getProducts);
            app.MapGet("/get/dishes", GetDataEndpoints.getDishes);
        }
        public static async Task<IResult> prepMethods(IGetMethods methods)
        {
            var result = await methods.GetPreparingMethods();
            return Results.Ok(result);
        }
        public static async Task<IResult> getTags(IGetMethods methods)
        {
            var result = await methods.GetTags();
            return Results.Ok(result);
        }
        public static async Task<IResult> getProducts(IGetMethods methods)
        {
            var result = await methods.GetProducts();
            return Results.Ok(result);
        }
        public static async Task<IResult> getDishes(IGetMethods methods)
        {
            var result = await methods.GetDishes();
            return Results.Ok(result);
        }
    }
}
