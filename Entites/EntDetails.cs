using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntDetails
    {
        public string? UserId { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? Ethnicity { get; set; }
        public string? NeckSize { get; set; }
        public string? BMI { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CreationDateTime { get; set; }



        public string? MedicalCondition { get; set; }
        public string? PastSurgery { get; set; }
        public string? PastSurgeryDetails { get; set; }
        public string? Smoke { get; set; }
        public string? AlcoholUse { get; set; }
        public string? IllegalDrugUse { get; set; }
        public string? DrugsCurrentlyUse { get; set; }
        public string? FamilySleepDisorders { get; set; }
        public string? Medications { get; set; }
        public string? MedicationsAllergic { get; set; }
        public string? AllergicReactionTypes { get; set; }



        public string? SittingAndReading { get; set; }
        public string? SittingAndWatchingTV { get; set; }
        public string? SittingInactiveInPublic { get; set; }
        public string? AsaPassengerCar { get; set; }
        public string? LyingDown { get; set; }
        public string? SittingTalking { get; set; }
        public string? SittingQuietfly { get; set; }
        public string? WhileStopped { get; set; }


    }
}
