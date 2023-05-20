using DishesApp.Entities;
using DishesApp.Exceptions;
using Microsoft.AspNetCore.Http;

namespace DishesApp.Middleware
{
    public class ErrorHandlingMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException message)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(message.Message);
            }
            
            catch(Exception e)
            {
                var error = e;
                //var message = error.InnerException.Message.Split(",");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(error.ToString());
            }
        }
    }
}
