using AutoMapper;
using Core.Entities;
using SecondApi.Dtos;
namespace SecondApi.Helpers
{
    public class MappingProfiles : Profile
    {   


        public MappingProfiles() {
            CreateMap<Product, ProductToReturn>()
                 .ForMember(d => d.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name))
                .ForMember(d => d.ProductTYPE, O => O.MapFrom(S => S.ProductTYPE.ToString()))
                .ForMember(dest => dest.PictureURL, opt => opt.ResolveUsing<ProductUrlResolver>());
        }
    }
}
