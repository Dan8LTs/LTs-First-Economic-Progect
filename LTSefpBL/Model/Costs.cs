using System;

namespace LTSefpBL.Model
{
    [Serializable]
    public class Costs
    {
        public int Id { get; set; }
        public string Name { get; }
        public double Price { get; }
        public object Key { get; set; }

        public Costs(string name) : this(name, 0) { }


        public Costs(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
