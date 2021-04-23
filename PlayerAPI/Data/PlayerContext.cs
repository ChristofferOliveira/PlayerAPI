using Microsoft.EntityFrameworkCore;
using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> opt) : base(opt)
        {

        }

        public DbSet<Player> Players { get; set; }

    }
}
