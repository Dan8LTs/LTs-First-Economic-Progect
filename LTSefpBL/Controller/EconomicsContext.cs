using LTSefpBL.Model;
using System;
using System.Data.Entity;


namespace LTSefpBL.Controller
{
    public class EconomicsContext : DbContext
    {
        public EconomicsContext() : base("DBConnection") { }

        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<ContributionA> ContributionsA { get; set; }

        public DbSet<Costs> Costs { get; set; }

        public DbSet<CostsA> CostsA { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<IncomeType> IncomeTypes { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
