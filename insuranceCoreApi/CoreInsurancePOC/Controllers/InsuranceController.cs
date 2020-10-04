using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreInsurancePOC.Interface;
using Domain.Dto;
using Domain.Models;
using InfraStructure.Interrface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreInsurancePOC.Controllers
{
   // [Route("api/Insurance")]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceRepository<Contract> _lifeInsuranceRepository;
        private readonly IInsuranceService _lifeInsuranceService;
        public InsuranceController(IInsuranceRepository<Contract> InsuranceRepository, IInsuranceService InsuranceService)
        {
            _lifeInsuranceRepository = InsuranceRepository;
            _lifeInsuranceService = InsuranceService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Contract> contracts = _lifeInsuranceRepository.GetAll();

            if (contracts.Count() == 0)
            {
                return NotFound("The Contracts couldn't be found.");
            }

            return Ok(contracts);
        }

        // POST: api/LifeInsurance
        [HttpPost]
        public IActionResult Post([FromBody] ContractDetails contractDetails)
        {
            if (contractDetails == null)
            {
                return BadRequest("Contract is null.");
            }

            Contract contract = _lifeInsuranceService.CreateContract(contractDetails);

            return Ok("Contract created successfully, CotractId: " + contract.ContractId);
        }

        // PUT: api/LifeInsurance
        [HttpPut("{ContractId}")]
        public IActionResult Put(string ContractId, [FromBody] ContractDetails contractDetails)
        {
            if (contractDetails == null)
            {
                return BadRequest("Contract is null.");
            }

            string response = _lifeInsuranceService.UpdateContract(ContractId, contractDetails);

            return Ok(response);
        }


        // DELETE: api/LifeInsurance/Contractid
        [HttpDelete("{ContractId}")]
        public IActionResult Delete(string ContractId)
        {
            Contract Contract = _lifeInsuranceService.GetContract(ContractId);

            if (Contract == null)
            {
                return NotFound("The Contract record couldn't be found.");
            }

            _lifeInsuranceService.DeleteContract(Contract);

            return NoContent();
        }
        //// GET: api/Insurance
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Insurance/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Insurance
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Insurance/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
