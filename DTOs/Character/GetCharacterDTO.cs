using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.DTOs.Character
{
    public class GetCharacterDTO
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "NoName";
        public int Health { get; set; } = 100;
        public int STR { get; set; } = 10;
        public int DEF { get; set; } = 10;
        public int INT { get; set; } = 10;
        public Classes Class { get; set; } = Classes.Mage;
    }
}