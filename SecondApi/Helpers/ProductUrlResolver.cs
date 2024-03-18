using AutoMapper;
using Core.Entities;
using SecondApi.Dtos;
using Microsoft.Extensions.Configuration;

namespace SecondApi.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product,ProductToReturn,string>
    {
        public readonly IConfiguration _configuration;

        public ProductUrlResolver() { }
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureURL))
                return _configuration["ApiUrl"]+source.PictureURL;

            return null;
        }
    }
}
