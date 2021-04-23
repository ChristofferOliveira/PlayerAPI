using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Nome { get; set; }
        
        [Required]
        public int Level { get; set; }
    }
}
