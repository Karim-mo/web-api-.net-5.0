using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using web_api_course_.net_5._0.DTOs.Character;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> chars = new List<Character>{
            new Character(),
            new Character {ID = 1, Name = "T", Class = Classes.Cleric}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<Response<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO c)
        {
            var response = new Response<List<GetCharacterDTO>>();
            Character _c = _mapper.Map<Character>(c);
            _c.ID = chars.Count;
            _c.Health = 100;
            chars.Add(_c);
            response.data = chars.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<Response<GetCharacterDTO>> DeleteCharacter(int id)
        {
            var response = new Response<GetCharacterDTO>();
            Character c = chars.FirstOrDefault(c => c.ID == id);

            if (c != null)
            {
                chars.RemoveAt(id);
                response.data = _mapper.Map<GetCharacterDTO>(c);
                return response;
            }
            else
            {
                throw new NullReferenceException("Character not found");
            }
        }

        public async Task<Response<List<GetCharacterDTO>>> GetAll()
        {
            var response = new Response<List<GetCharacterDTO>>();
            response.data = chars.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<Response<GetCharacterDTO>> GetOne(int id)
        {
            var response = new Response<GetCharacterDTO>();
            response.data = _mapper.Map<GetCharacterDTO>(chars.FirstOrDefault(c => c.ID == id));
            return response;
        }

        public async Task<Response<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO c)
        {
            var response = new Response<GetCharacterDTO>();
            try
            {
                Character _c = chars.First(_char => _char.ID == c.ID);
                _c.Name = c.Name;
                _c.STR = c.STR;
                _c.DEF = c.DEF;
                _c.INT = c.INT;

                response.data = _mapper.Map<GetCharacterDTO>(_c);
            }
            catch (Exception e)
            {
                throw new NullReferenceException("Can't update character");
            }

            return response;
        }
    }
}
