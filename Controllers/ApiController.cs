using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api")]
    public class ApiController
    {
        public string Api()
        {
            return "Welcome to ASP.NET Core Web API!";
        }
    }
}
