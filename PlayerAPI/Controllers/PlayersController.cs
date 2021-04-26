using Microsoft.AspNetCore.Mvc;
using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerAPI.Data;
using AutoMapper;
using PlayerAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace PlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<PlayerReadDto>> GetAllPlayers()
        {
            var playerItems = _repository.GetPlayer();

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(playerItems));
        }

        //GET api/players/{id}
        [HttpGet("{id}", Name = "GetPlayerById")]
        public ActionResult<PlayerReadDto> GetPlayerById(int id)
        {
            var playerItems = _repository.GetPlayerById(id);

            if (playerItems != null)
                return Ok(_mapper.Map<PlayerReadDto>(playerItems));

            return NotFound();
        }

        //POST api/players
        [HttpPost]
        public ActionResult<PlayerReadDto> CreatePlayer(PlayerCreateDto playerCreateDto)
        {
            var playerModel = _mapper.Map<Player>(playerCreateDto);
            _repository.CreatePlayer(playerModel);
            _repository.SaveChanges();

            var playerReadDto = _mapper.Map<PlayerReadDto>(playerModel);

            return CreatedAtRoute(nameof(GetPlayerById), new { Id = playerReadDto.Id }, playerReadDto);
        }

        //PUT api/players/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(int id, PlayerUpdateDto playerUpdateDto)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if(playerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(playerUpdateDto, playerModelFromRepo);

            _repository.UpdatePlayer(playerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/players/{id}
        [HttpPatch("id")]
        public ActionResult PartialPlayerUpdate(int id, JsonPatchDocument<PlayerUpdateDto> patchDoc)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null)
            {
                return NotFound();
            }

            var playerToPatch = _mapper.Map<PlayerUpdateDto>(playerModelFromRepo);
            patchDoc.ApplyTo(playerToPatch, ModelState);
            
            if (!TryValidateModel(playerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(playerToPatch, playerModelFromRepo);

            _repository.UpdatePlayer(playerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/players/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(int id)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePlayer(playerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
