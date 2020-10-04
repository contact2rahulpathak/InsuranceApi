using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class Contract
    {
        public string ContractId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        public DateTime CustomerDateofbirth { get; set; }
        public DateTime SaleDate { get; set; }
        public string CoveragePlan { get; set; }
        public decimal NetPrice { get; set; }
    }
}

