using System;

namespace WpfApplication2.Models
{
    public class WorkPermit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? PeriodFrom { get; set; }

        public DateTime? PeriodTo { get; set; }
    }
}