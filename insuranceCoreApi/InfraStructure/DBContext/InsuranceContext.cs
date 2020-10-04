using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Dto;


namespace InfraStructure.DBContext
{
   
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //This will come from  using Insurance.Domain.Dtos;
            modelBuilder.Entity<Contract>().HasKey(p => p.ContractId);
        }
        public virtual DbSet<Contract> Contracts { get; set; }
    }
}
