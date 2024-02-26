using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntFeedBack
    {
        public string? UserId { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Feedback { get; set; }
        public string? DateTime { get; set; }
    }
}
