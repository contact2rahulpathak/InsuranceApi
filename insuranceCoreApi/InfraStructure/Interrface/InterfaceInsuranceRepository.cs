using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Interrface
{
   
    public interface IInsuranceRepository<Contract>
    {
        IEnumerable<Contract> GetAll();
        Contract Get(string id);
        void Add(Contract contract);
        void Update(Contract dbEntity, Contract entity);
        void Delete(Contract entity);
    }
}
