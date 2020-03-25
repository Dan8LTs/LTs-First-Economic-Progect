using System;
using System.Collections.Generic;
using System.Linq;

namespace LTSefpBL.Model
{
    [Serializable]
    public class CostsA
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Dictionary<Costs, double> Cost { get; }

        public virtual User User { get; }

        public CostsA(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Cost = new Dictionary<Costs, double>();
        }

        public void Add(Costs cost, double price)
        {
            var cos = Cost.Keys.FirstOrDefault(f => f.Name.Equals(cost.Name));
            if (cos == null)
            {
                Cost.Add(cost, price);
            }
            else
            {
                Cost[cos] += price;
            }
        }
    }
}
