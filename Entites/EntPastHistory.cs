using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntPastHistory
    {
    
        [Required] public string? UserId { get; set; }
        [Required] public string? MedicalCondition { get; set; }
        [Required] public string? PastSurgery { get; set; }
        [Required] public string? PastSurgeryDetails { get; set; }
        [Required] public string? Smoke { get; set; }
        [Required] public string? AlcoholUse { get; set; }
        [Required] public string? IllegalDrugUse { get; set; }
        [Required] public string? DrugsCurrentlyUse { get; set; }
        [Required] public string? FamilySleepDisorders { get; set; }
        [Required] public string? Medications { get; set; }
        [Required] public string? MedicationsAllergic { get; set; }
        [Required] public string? AllergicReactionTypes { get; set; }


    }
}
