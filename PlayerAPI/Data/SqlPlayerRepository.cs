using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Data
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private readonly PlayerContext _context;

        public SqlPlayerRepository(PlayerContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetPlayer()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }
    }
}
