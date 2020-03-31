using System;
using System.Collections.Generic;
using System.Linq;

namespace LTSefpBL.Model
{
    [Serializable]
    public class ContributionA
    {
        public int Id { get; set; }
        public Dictionary<Contribution, double> Contributions { get; }
        public virtual User User { get; }
        public ContributionA() { }
        public ContributionA(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Contributions = new Dictionary<Contribution, double>();
        }

        public void Add(Contribution contr, double res)
        {
            var cont = Contributions.Keys.FirstOrDefault(f => f.Name.Equals(contr.Name));
            if (cont == null)
            {
                Contributions.Add(contr, res);
            }
            else
            {
                Contributions[cont] += res;
            }
        }
    }
}
