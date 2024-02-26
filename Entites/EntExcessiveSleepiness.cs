﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class EntExcessiveSleepiness
    {
        public string? fk_UserId { get; set; }
        [Required] public string? CurrentPosition { get; set; }
        [Required] public string? TypicallyWork { get; set; }
        [Required] public string? SleepPerNight { get; set; }
        [Required] public string? UseElectronics { get; set; }
        [Required] public string? BedTime { get; set; }
        [Required] public string? SleepEnvironement  { get; set; }

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
