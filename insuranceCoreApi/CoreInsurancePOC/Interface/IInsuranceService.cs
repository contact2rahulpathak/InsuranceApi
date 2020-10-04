using Domain.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreInsurancePOC.Interface
{
    public interface IInsuranceService
    {
        public Contract CreateContract(ContractDetails contractDetails);
        public Contract GetContract(string contractId);
        public string UpdateContract(string contractId, ContractDetails contractDetails);
        public string DeleteContract(Contract contract);
    }
}
