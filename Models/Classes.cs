using System.Text.Json.Serialization;

namespace web_api_course_.net_5._0.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Classes
    {
        Cleric,
        Warrior,
        Mage
    }
}
