using LTSefpBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTSefpBL.Controller
{
    public class CostsAController : ControllerBase
    {
        private const string COSTS_FILE_NAME = "costs.dat";
        private const string COSTSA_FILE_NAME = "costsa.dat";

        private readonly User user;
        public List<Costs> Costs { get; }

        public CostsA Cost { get; }
        public CostsAController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can't be empty", nameof(user));
            Cost = GetCostsA();
            Costs = GetAllCosts();
        }

        public void Add(Costs cost, double price)
        {
            var costs = Costs.SingleOrDefault(c => c.Name == cost.Name);
            if (costs == null)
            {
                Costs.Add(cost);
                Cost.Add(cost, price);
                Save();
            }
            else
            {
                Cost.Add(costs, price);
                Save();
            }
        }

        private CostsA GetCostsA()
        {
            return Load<CostsA>().FirstOrDefault() ?? new CostsA(user);
        }


        private List<Costs> GetAllCosts()
        {
            return Load<Costs>() ?? new List<Costs>();
        }
        public void Save()
        {
            Save(Costs);
            Save(new List<CostsA>() { Cost });
        }
    }
}
