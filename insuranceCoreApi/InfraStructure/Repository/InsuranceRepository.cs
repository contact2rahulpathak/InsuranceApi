using InfraStructure.DBContext;
using InfraStructure.Interrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Dto;

namespace InfraStructure.Repository
{
   
    public class InsuranceRepository : IInsuranceRepository<Contract>
    {
        readonly InsuranceContext _InsuranceContext;

        public InsuranceRepository(InsuranceContext InsuranceContext)
        {
            _InsuranceContext = InsuranceContext;
        }
        public void Add(Contract contract)
        {
            _InsuranceContext.Contracts.Add(contract);
            _InsuranceContext.SaveChanges();
        }

        public void Delete(Contract contracts)
        {
            _InsuranceContext.Contracts.Remove(contracts);
            _InsuranceContext.SaveChanges();
        }

        public Contract Get(string contractId)
        {
            return _InsuranceContext.Contracts
                  .FirstOrDefault(e => e.ContractId == contractId);
        }

        public IEnumerable<Contract> GetAll()
        {
            return _InsuranceContext.Contracts.ToList();
        }

        public void Update(Contract contractToUpdate, Contract contract)
        {
            contractToUpdate.CustomerName = contract.CustomerName;
            contractToUpdate.CoveragePlan = contract.CoveragePlan;
            contractToUpdate.CustomerAddress = contract.CustomerAddress;
            contractToUpdate.CustomerCountry = contract.CustomerCountry;
            contractToUpdate.CustomerDateofbirth = contract.CustomerDateofbirth;
            contractToUpdate.CustomerGender = contract.CustomerGender;
            contractToUpdate.SaleDate = contract.SaleDate;
            contractToUpdate.NetPrice = contract.NetPrice;
            _InsuranceContext.SaveChanges();
        }
    }
}
