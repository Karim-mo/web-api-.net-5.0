using System;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Controllers
{

    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorHandlerController : ControllerBase
    {
        [HttpGet]
        [Route("/errors")]
        public IActionResult HandleError()
        {
            var cont = HttpContext.Features.Get<IExceptionHandlerFeature>();
            HttpContext.Response.ContentType = "application/json";
            // Can add status code in response json for frontend to deal with it since asp.net is so amazing
            return Content(new ErrorDetails
            {
                response = new Response
                {
                    data = new Data
                    {
                        message = cont.Error.Message,
                        stack = cont.Error.StackTrace
                    }
                }
            }.ToString());
        }
    }

    internal class ErrorDetails
    {
        public Response response { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }


    internal class Response
    {
        public Data data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    internal class Data
    {
        public string stack { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}