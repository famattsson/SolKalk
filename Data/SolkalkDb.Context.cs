﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SolkalkDbEntities : DbContext
    {
        public SolkalkDbEntities()
            : base("name=SolkalkDbEntities")
        {
        }

        static SolkalkDbEntities()
        {
            var foo = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ProducedCompanyPower> ProducedCompanyPowers { get; set; }
        public virtual DbSet<ProducedMunicipalPower> ProducedMunicipalPowers { get; set; }
    }
}
