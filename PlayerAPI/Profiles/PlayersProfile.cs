using AutoMapper;
using PlayerAPI.Dtos;
using PlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Profiles
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            CreateMap<Player, PlayerReadDto>();
            CreateMap<PlayerCreateDto, Player>();
        }
    }
}
