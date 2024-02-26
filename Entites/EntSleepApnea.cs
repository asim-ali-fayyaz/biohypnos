using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntSleepApnea
    {
        public string? fk_UserId { get; set; }
        
        [Required] public string? SnoreLoudly { get; set; }
        [Required] public string? OftenFeelTired { get; set; }
        [Required] public string? StopBreating { get; set; }
        [Required] public string? BloodPressure { get; set; }
        [Required] public string? WakeUp { get; set; }
        [Required] public string? SpendSleepTime { get; set; }
        [Required] public string? MorningHeadache { get; set; }
        [Required] public string? ScheduledUnscheduled { get; set; }
        [Required] public string? GainedWeight { get; set; }
        [Required] public string? AboutYourSleep { get; set; }
        [Required] public string? SittingAndReading { get; set; }
        [Required] public string? SittingAndWatchingTV { get; set; }
        [Required] public string? SittingInactiveInPublic { get; set; }
        [Required] public string? AsaPassengerCar { get; set; }
        [Required] public string? LyingDown { get; set; }
        [Required] public string? SittingTalking { get; set; }
        [Required] public string? SittingQuietfly { get; set; }
        [Required] public string? WhileStopped { get; set; }
    }
}
