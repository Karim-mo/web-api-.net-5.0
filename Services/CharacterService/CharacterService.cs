using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> chars = new List<Character>{
            new Character(),
            new Character {ID = 1, Name = "T", Class = Classes.Cleric}
        };

        public async Task<List<Character>> AddCharacter(Character c)
        {
            chars.Add(c);
            return chars;
        }

        public async Task<List<Character>> GetAll()
        {
            return chars;
        }

        public async Task<Character> GetOne(int id)
        {
            return chars.FirstOrDefault(c => c.ID == id);
        }
    }
}
