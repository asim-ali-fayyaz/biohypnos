using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntLegMovements
    {
        public string? fk_UserId { get; set; }
        [Required] public string? Uncomfortable { get; set; }
        [Required] public string? Urge { get; set; }
        [Required] public string? Sensation { get; set; }
        [Required] public string? Symptoms { get; set; }
        [Required] public string? Following { get; set; }
        [Required] public string? Occasions { get; set; }
        [Required] public string? TimesPerWeek { get; set; }

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
