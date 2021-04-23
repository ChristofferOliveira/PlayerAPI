﻿using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> GetPlayer()
        {
            var players = new List<Player>
            {
                new Player { Id = 0, Level = 0, Nome = "Michael" },
                new Player { Id = 1, Level = 3, Nome = "Jay" },
                new Player { Id = 2, Level = 5, Nome = "Lisa" }
            };

            return players;
        }

        public Player GetPlayerById(int id)
        {
            return new Player { Id = 0, Level = 0, Nome = "Michael" };
        }
    }
}
