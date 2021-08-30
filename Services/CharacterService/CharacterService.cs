using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using web_api_course_.net_5._0.Data;
using web_api_course_.net_5._0.DTOs.Character;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public async Task<Response<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO c)
        {
            var response = new Response<List<GetCharacterDTO>>();
            Character _c = _mapper.Map<Character>(c);
            _c.Health = 100;
            context.Characters.Add(_c);
            await context.SaveChangesAsync();
            response.data = await context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            return response;
        }

        public async Task<Response<GetCharacterDTO>> DeleteCharacter(int id)
        {
            var response = new Response<GetCharacterDTO>();
            Character c = await context.Characters.FirstOrDefaultAsync(c => c.ID == id);

            if (c != null)
            {
                context.Characters.Remove(c);
                await context.SaveChangesAsync();
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
            var _chars = await context.Characters.ToListAsync();
            response.data = _chars.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<Response<GetCharacterDTO>> GetOne(int id)
        {
            var response = new Response<GetCharacterDTO>();
            var c = await context.Characters.FirstOrDefaultAsync(c => c.ID == id);
            if (c != null)
            {
                response.data = _mapper.Map<GetCharacterDTO>(c);
                return response;
            }
            else
            {
                throw new NullReferenceException("Character not found");
            }

        }

        public async Task<Response<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO c)
        {
            var response = new Response<GetCharacterDTO>();

            Character _c = await context.Characters.FirstOrDefaultAsync(_char => _char.ID == c.ID);
            if (_c != null)
            {
                _c.Name = c.Name;
                _c.STR = c.STR;
                _c.DEF = c.DEF;
                _c.INT = c.INT;

                await context.SaveChangesAsync();

                response.data = _mapper.Map<GetCharacterDTO>(_c);
                return response;
            }
            else
            {
                throw new NullReferenceException("Can't update character");

            }
        }
    }
}
