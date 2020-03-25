using LTSefpBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTSefpBL.Controller
{
    public class ContributionController : ControllerBase
    {
        private readonly User user;
        public List<Contribution> Contribution { get; }
        public ContributionA Contrib { get; }
        public ContributionController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Contrib = GetContributionA();
            Contribution = GetAllContributions();
        }

        public void Add(Contribution contrib, double res)
        {
            var contributions = Contribution.SingleOrDefault(c => c.Name == contrib.Name);
            if (contributions == null)
            {
                Contribution.Add(contrib);
                Contrib.Add(contrib, res);
                Save();
            }
            else
            {
                Contrib.Add(contributions, res);
                Save();
            }
        }

        private ContributionA GetContributionA()
        {
            return Load<ContributionA>().FirstOrDefault() ?? new ContributionA(user);
        }


        private List<Contribution> GetAllContributions()
        {
            return Load<Contribution>() ?? new List<Contribution>();
        }
        public void Save()
        {
            Save(Contribution);
            Save(new List<ContributionA> { Contrib });
        }
    }
}
