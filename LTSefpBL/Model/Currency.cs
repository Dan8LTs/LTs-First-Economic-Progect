using LTSefpBL.Controller;
using System.Collections.Generic;


namespace LTSefpBL.Model
{
    public class Currency : ControllerBase
    {
        public int Id { get; set; }
        public string Name { get; }

        public float Price { get; }

        public List<Currency> currencies;
        public Currency(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public static double Translate(string name, float price, float earning)
        {
            return earning / price;
        }
    }
}
