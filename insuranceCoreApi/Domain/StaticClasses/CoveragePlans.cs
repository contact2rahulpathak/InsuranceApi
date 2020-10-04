using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.StaticClasses
{
    public static class CoveragePlans
    {
        public static List<CoveragePlan> coveragePlans;
        static CoveragePlans()
        {
            coveragePlans = new List<CoveragePlan>();
            CoveragePlan coveragePlan1 = new CoveragePlan();
            coveragePlan1.CoveragePlanType = "Gold";
            coveragePlan1.EligibilityDateFrom = Convert.ToDateTime("1/1/2009");
            coveragePlan1.EligibilityDateTo = Convert.ToDateTime("1/1/2021");
            coveragePlan1.EligibilityCountry = "USA";
            CoveragePlan coveragePlan2 = new CoveragePlan();
            coveragePlan2.CoveragePlanType = "Platinum";
            coveragePlan2.EligibilityDateFrom = Convert.ToDateTime("1/1/2005");
            coveragePlan2.EligibilityDateTo = Convert.ToDateTime("1/1/2023");
            coveragePlan2.EligibilityCountry = "CNA";
            CoveragePlan coveragePlan3 = new CoveragePlan();
            coveragePlan3.CoveragePlanType = "Silver";
            coveragePlan3.EligibilityDateFrom = Convert.ToDateTime("1/1/2001");
            coveragePlan3.EligibilityDateTo = Convert.ToDateTime("1/1/2026");
            coveragePlan3.EligibilityCountry = "ANY";
            coveragePlans.Add(coveragePlan1);
            coveragePlans.Add(coveragePlan2);
            coveragePlans.Add(coveragePlan3);
        }
    }
}
