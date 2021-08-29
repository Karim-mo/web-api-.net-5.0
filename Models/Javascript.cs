using Microsoft.AspNetCore.Http;

namespace web_api_course_.net_5._0.Models
{
    public static class Javascript
    {
        static string scriptTag = "<script type=\"\" language=\"\">{0}</script>";
        public static string ConsoleLog(string message)
        {
            string function = "console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            return log;
        }

        public static string Alert(string message)
        {
            string function = "alert('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            return log;
        }

        static string GenerateCodeFromFunction(string function)
        {
            return string.Format(scriptTag, function);
        }
    }
}