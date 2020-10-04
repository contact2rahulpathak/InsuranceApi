using CoreInsurancePOC.Interface;
using Domain.Dto;
using Domain.Models;
using Domain.StaticClasses;
using InfraStructure.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreInsurancePOC;

namespace CoreInsurancePOC.Service
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository<Contract> _InsuranceRepository;
        public InsuranceService(IInsuranceRepository<Contract> InsuranceRepository)
        {
            _InsuranceRepository = InsuranceRepository;
        }
        public Contract CreateContract(ContractDetails contractDetails)
        {
            Contract contract = new Contract();
            try
            {
                Random r = new Random();

                CoveragePlan coveragePlan = GetCoveragePlan(contractDetails);

                int age = GetAge(contractDetails.CustomerDateOfBirth);

                int netPrice = GetNetPrice(coveragePlan.CoveragePlanType.ToUpper(), age, contractDetails.CustomerGender);

                if (coveragePlan != null)
                {
                    contract = new Contract
                    {
                        ContractId = "LIC" + r.Next().ToString(),
                        CustomerName = contractDetails.CustomerName,
                        CustomerAddress = contractDetails.CustomerAddress.City,
                        CustomerGender = contractDetails.CustomerGender,
                        CustomerCountry = contractDetails.CustomerAddress.Country,
                        CustomerDateofbirth = contractDetails.CustomerDateOfBirth,
                        SaleDate = contractDetails.SaleDate,
                        CoveragePlan = coveragePlan.CoveragePlanType,
                        NetPrice = netPrice
                    };
                    _InsuranceRepository.Add(contract);
                }
            }
            catch (Exception Ex)
            {
                //Log exception
            }
            return contract;
        }

        public string UpdateContract(string contractId, ContractDetails contractDetails)
        {
            Contract contract = new Contract();
            try
            {
                Contract contractToUpdate = _InsuranceRepository.Get(contractId);

                if (contractToUpdate == null)
                {
                    return "The Contract record couldn't be found.";
                }

                CoveragePlan coveragePlan = GetCoveragePlan(contractDetails);
               // int a = Utility.
                int age = GetAge(contractDetails.CustomerDateOfBirth);

                int netPrice = GetNetPrice(coveragePlan.CoveragePlanType.ToUpper(), age, contractDetails.CustomerGender);

                if (coveragePlan != null)
                {
                    contract = new Contract
                    {
                        ContractId = contractId,
                        CustomerName = contractDetails.CustomerName,
                        CustomerAddress = contractDetails.CustomerAddress.City,
                        CustomerGender = contractDetails.CustomerGender,
                        CustomerCountry = contractDetails.CustomerAddress.Country,
                        CustomerDateofbirth = contractDetails.CustomerDateOfBirth,
                        SaleDate = contractDetails.SaleDate,
                        CoveragePlan = coveragePlan.CoveragePlanType,
                        NetPrice = netPrice
                    };
                }
                _InsuranceRepository.Update(contractToUpdate, contract);
            }
            catch (Exception Ex)
            {
                return "Failed to update contract.";
            }
            return "Contract updated successfully.";
        }

        public Contract GetContract(string contractId)
        {
            Contract contract = _InsuranceRepository.Get(contractId);
            return contract;
        }

        public string DeleteContract(Contract contract)
        {
            _InsuranceRepository.Delete(contract);
            return "Contract deleted succussfully";
        }
        public CoveragePlan GetCoveragePlan(ContractDetails contractDetails)
        {
            List<CoveragePlan> coveragePlans = CoveragePlans.coveragePlans;

            var plan = coveragePlans.Where(c => (c.EligibilityDateFrom <= contractDetails.SaleDate && c.EligibilityDateTo >= contractDetails.SaleDate) && (c.EligibilityCountry == contractDetails.CustomerAddress.Country)).FirstOrDefault();

            if (plan == null)
            {
                plan = coveragePlans.Where(c => (c.EligibilityDateFrom <= contractDetails.SaleDate && c.EligibilityDateTo >= contractDetails.SaleDate) && (c.EligibilityCountry == "ANY")).FirstOrDefault();
            }
            return plan;
        }
      
            public enum PlanType { Gold, Silver, Platinam };
            public  int GetAge(DateTime DOB)
            {
                // Calculate the age.
                var age = DateTime.Today.Year - DOB.Year;

                // Go back to the year the person was born in case of a leap year
                if (DOB.Date > DateTime.Today.AddYears(-age)) age--;

                return age;
            }

            public  int GetNetPrice(string planType, int age, string gender)
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

