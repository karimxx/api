using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SecondApi.Errors;
using System.Linq;

namespace SecondApi.Extientions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGeneticRepository<>), (typeof(GeneticRepository<>)));
            services.Configure<ApiBehaviorOptions>
          (options =>
          {
              options.InvalidModelStateResponseFactory = actionContext =>
              {
                  var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                  .SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();
                  var errorresponse = new ApiValidationResponse
                  {
                      Errors = errors
                  };
                  return new BadRequestObjectResult(errorresponse);
              };
          });
            return services;
        }
    }
}
