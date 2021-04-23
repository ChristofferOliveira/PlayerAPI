using Microsoft.AspNetCore.Mvc;
using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerAPI.Data;

namespace PlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _repository;

        public PlayersController(IPlayerRepository repository)
        {
            _repository = repository;
        }

        //private readonly PlayerRepository _repository = new PlayerRepository();

        [HttpGet]
        public ActionResult <IEnumerable<Player>> GetAllPlayers()
        {
            var playerItems = _repository.GetPlayer();
            
            return Ok(playerItems);
        }

        [HttpGet("{id}")]
        public ActionResult <Player> GetPlayerById(int id)
        {
            var playerItems = _repository.GetPlayerById(id);

            return Ok(playerItems);
        }
    }
}
