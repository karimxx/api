using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecondApi.Errors;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecondApi.Middelware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            
                var errorResponse = env.IsDevelopment() ?
                    new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    :
                    new ApiExceptions((int)HttpStatusCode.InternalServerError);

              
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorResponse, options);
                await context.Response.WriteAsync(json);

            }
        }
    }
}
