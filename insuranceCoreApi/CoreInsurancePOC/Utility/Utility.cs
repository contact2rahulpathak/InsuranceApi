using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInsurancePOC.Utility
{
    public static class Utility
    {
        public enum PlanType { Gold, Silver, Platinam };
        public static int GetAge(DateTime DOB)
        {
            // Calculate the age.
            var age = DateTime.Today.Year - DOB.Year;

            // Go back to the year the person was born in case of a leap year
            if (DOB.Date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }

        public static int GetNetPrice(string planType, int age, string gender)
        {
            int netPrice = 0;
            switch (planType)
            {
                case "GOLD":
                    netPrice = gender == "M" ? (age <= 40 ? 1000 : 2000) : (age <= 40 ? 1200 : 2500);
                    break;
                case "SILVER":
                    netPrice = gender == "M" ? (age <= 40 ? 1500 : 2600) : (age <= 40 ? 1900 : 2800);
                    break;
                case "PLATINUM":
                    netPrice = gender == "M" ? (age <= 40 ? 1900 : 2900) : (age <= 40 ? 2100 : 3200);
                    break;
            }
            return netPrice;
        }
    }
}
