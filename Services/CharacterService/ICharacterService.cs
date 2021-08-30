using System.Collections.Generic;
using System.Threading.Tasks;
using web_api_course_.net_5._0.DTOs.Character;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Services.CharacterService
{
    // TODO: Implement Delete character
    public interface ICharacterService
    {
        Task<Response<List<GetCharacterDTO>>> GetAll();
        Task<Response<GetCharacterDTO>> GetOne(int id);
        Task<Response<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO c);
        Task<Response<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO c);
        Task<Response<GetCharacterDTO>> DeleteCharacter(int id);
    }
}