using System.Collections.Generic;
using System.Threading.Tasks;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAll();
        Task<Character> GetOne(int id);
        Task<List<Character>> AddCharacter(Character c);
    }
}