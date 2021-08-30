using System;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Controllers
{
    public static class ErrorHandlerController
    {
        public static string HandleError(string message, string trace)
        {
            return new ErrorDetails
            {
                response = new Response
                {
                    data = new Data
                    {
                        message = message,
                        stack = trace
                    }
                }
            }.ToString();
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