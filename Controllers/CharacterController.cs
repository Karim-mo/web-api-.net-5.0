using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_api_course_.net_5._0.DTOs.Character;
using web_api_course_.net_5._0.Models;
using web_api_course_.net_5._0.Services.CharacterService;

namespace web_api_course_.net_5._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response<List<GetCharacterDTO>>>> GetAll()
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<GetCharacterDTO>>> GetOne(int id)
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<GetCharacterDTO>>>> AddCharacter(AddCharacterDTO c)
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.AddCharacter(c));
        }

        [HttpPut]
        public async Task<ActionResult<Response<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO c)
        {
            return Ok(await _characterService.UpdateCharacter(c));
        }

        [HttpDelete]
        public async Task<ActionResult<Response<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            return Ok(await _characterService.DeleteCharacter(id));
        }
    }
}