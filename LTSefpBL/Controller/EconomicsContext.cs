using LTSefpBL.Model;
using System.Data.Entity;


namespace LTSefpBL.Controller
{
    public class EconomicsContext : DbContext
    {
        public EconomicsContext() : base("LTsEconomicDB") { }

        public DbSet<Contribution> Contributionss { get; set; }

        public DbSet<ContributionA> ContributionsAs { get; set; }

        public DbSet<Costs> Costss { get; set; }

        public DbSet<CostsA> CostsAs { get; set; }

        public DbSet<IncomeType> IncomeTypes { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
