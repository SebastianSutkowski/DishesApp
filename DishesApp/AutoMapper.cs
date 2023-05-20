using AutoMapper;
using DishesApp.Dto;
using DishesApp.Entities;

namespace DishesApp
{
    public class AutoMapper : Profile
    {


        public AutoMapper()
        {
           
            CreateMap<Product, ProductGetDto>()
                .ForMember(dto=>dto.MeasurmentUnit,p=>p.MapFrom(pr=>pr.MeasurmentUnit.description));
            CreateMap<Tag,TagDto>();
            CreateMap<PreparingMethod, PreparingMethodsGetDto>();
            CreateMap<Dish, DishGetDto>()
                .ForMember(dto => dto.PreparingMethod, d => d.MapFrom(dsh => dsh.PreparingMethod.Name))
                .ForMember(dto => dto.Products, d => d.MapFrom(dsh => dsh.Products))
                .ForMember(dto => dto.Tags, d => d.MapFrom(dsh => dsh.Tags));

        }
    }
}
