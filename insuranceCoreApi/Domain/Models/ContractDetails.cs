using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ContractDetails
    {
        public string CustomerName { get; set; }
        public Address CustomerAddress { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public string CustomerGender { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
