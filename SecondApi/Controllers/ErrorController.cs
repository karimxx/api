using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondApi.Errors;

namespace SecondApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {

            return new ObjectResult(new ApiResponse(code));
        }

    }
}
