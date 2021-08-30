using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.DTOs.Character
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "New Player";
        public int STR { get; set; } = 10;
        public int DEF { get; set; } = 10;
        public int INT { get; set; } = 10;
        public Classes Class { get; set; } = Classes.Mage;
    }
}