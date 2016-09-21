using System;

namespace Webapplication.Models
{
    public class CalculationDto
    {
        public int Id { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int? Sum { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateProcessed { get; set; }
    }
}