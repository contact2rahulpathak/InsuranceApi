using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CoveragePlan
    {
        public string CoveragePlanType { get; set; }
        public DateTime EligibilityDateFrom { get; set; }
        public DateTime EligibilityDateTo { get; set; }
        public string EligibilityCountry { get; set; }
    }
}
