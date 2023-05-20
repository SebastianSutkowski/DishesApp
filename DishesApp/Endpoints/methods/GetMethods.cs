using AutoMapper;
using DishesApp.Dto;
using DishesApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DishesApp.Endpoints.methods
{
    public interface IGetMethods
    {
        Task<List<PreparingMethodsGetDto>> GetPreparingMethods();
        Task<List<TagDto>> GetTags();
        Task<List<ProductGetDto>> GetProducts();
        Task<List<DishGetDto>> GetDishes();
    }
    public class GetMethods : IGetMethods
    {
        private readonly DishesAppDbContext dbContext;
        private readonly IMapper mapper;

        public GetMethods(DishesAppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<PreparingMethodsGetDto>> GetPreparingMethods()
        {
            var coockMethods = await dbContext.PreparingMethods.ToListAsync();
            var preparingMethodsDtos = mapper.Map<List<PreparingMethodsGetDto>>(coockMethods);
            return preparingMethodsDtos;
        }
        public async Task<List<TagDto>> GetTags()
        {
            var tags = await dbContext.Tags.ToListAsync();
            var tagsDtos = mapper.Map<List<TagDto>>(tags);
            return tagsDtos;
        }
        public async Task<List<ProductGetDto>> GetProducts()
        {
            var products = await dbContext.Products.Include(p=>p.MeasurmentUnit).ToListAsync();
            var productDtos = mapper.Map<List<ProductGetDto>>(products);
            return productDtos;
        }
        public async Task<List<DishGetDto>> GetDishes()
        {
            var dishes = await dbContext.Dishes
                .Include(d => d.Recipe)
                .Include(d => d.PreparingMethod)
                .Include(d => d.Products)
                .ThenInclude(p=>p.MeasurmentUnit)
                .Include(d => d.Tags)
                .ToListAsync();
            var dishesDtos = mapper.Map<List<DishGetDto>>(dishes);
            return dishesDtos;
        }
    }

    
}
