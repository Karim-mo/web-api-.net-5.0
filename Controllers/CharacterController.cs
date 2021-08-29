using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Character>>> GetAll()
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetOne(int id)
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.GetOne(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character c)
        {
            HttpContext.Response.ContentType = "application/json";
            return Ok(await _characterService.AddCharacter(c));
        }
    }
}