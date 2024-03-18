using System.Globalization;

namespace SecondApi.Errors
{
    public class ApiExceptions : ApiResponse
    {
        public ApiExceptions(int statusCode, string massege = null, string details = null) : base(statusCode, massege)
        {
            Details = details;
        }
        public string Details { get; set; } 
    }
}
