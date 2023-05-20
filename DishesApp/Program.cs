using DishesApp.Endpoints;
using DishesApp.Endpoints.methods;

using DishesApp.Entities;
using DishesApp.FluentValidation;
using DishesApp.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DishesAppDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DishesAppConnectionString"))
    ) ;
builder.Services.AddScoped<ErrorHandlingMiddleware>();
//endpoint methods
builder.Services.AddScoped<IGetMethods, GetMethods>();
builder.Services.AddScoped<IPostMethods, PostMethods>();
// validators
builder.Services.AddScoped<IValidator<Tag>, TagValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Dish>, DishValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TagValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DishValidator>();
//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DishesAppDbContext>();
    //var dataList = ;
    if (!dbContext.MeasurmentUnits.ToList().Any())
    {

        List<string> measurmentUnits = new List<string>() { "ml", "l", "³y¿eczka", "³y¿ka", "szklanka", "g", "kg" };
        foreach(var measurmentUnit in measurmentUnits)
        {
            var mUnit = new MeasurmentUnit()
            {
                description = measurmentUnit
            };
            await dbContext.MeasurmentUnits.AddAsync(mUnit);
        }
        dbContext.SaveChanges();
    }
    if (!dbContext.PreparingMethods.ToList().Any())
    {

        List<string> preparingMethods = new List<string>() { "sma¿one", "pieczone", "gotowane", "na zimno" };
        foreach (var preparingMethod in preparingMethods)
        {
            var pMethod = new PreparingMethod()
            {
                Name = preparingMethod
            };
            await dbContext.PreparingMethods.AddAsync(pMethod);
        }
        dbContext.SaveChanges();
    }
    // use context
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.AddDataEndpointsSet();
app.GetDataEndpointsSet();

app.Run();

