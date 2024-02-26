using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntDemographic
    {
        public string? UserId { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Race { get; set; }
        [Required]
        public string? Ethnicity { get; set; }
        [Required]
        public string? NeckSize { get; set; }
        [Required]
        public string? BMI { get; set; }

    }
}
