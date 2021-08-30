namespace web_api_course_.net_5._0.Models
{
    public class Response<T>
    {
        public T data { get; set; }
        public int httpStatusCode { get; set; } = 200;
        public bool success { get; set; } = true;
        public string details { get; set; } = null;
    }
}