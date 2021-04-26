﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Dtos
{
    public class PlayerCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Required]
        public int Level { get; set; }
    }
}
