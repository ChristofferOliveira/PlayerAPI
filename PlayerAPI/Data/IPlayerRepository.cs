using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Data
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayer();
        Player GetPlayerById(int id);
    }
}
