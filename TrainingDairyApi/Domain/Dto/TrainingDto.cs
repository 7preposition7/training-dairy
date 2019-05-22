using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class TrainingDto
    {
        public int ID { get; set; }
        public int SportsmanID { get; set; }
        public TrainingType TrainingType { get; set; }
        public DateTime TrainingStart { get; set; }
        public int TrainingTimeInSeconds { get; set; }
        public short AmountOfSets { get; set; }
    }
}
