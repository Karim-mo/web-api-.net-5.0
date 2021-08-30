namespace web_api_course_.net_5._0.DTOs.Character
{
    public class UpdateCharacterDTO
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = "New Player";
        public int STR { get; set; } = 10;
        public int DEF { get; set; } = 10;
        public int INT { get; set; } = 10;
    }
}