using System;

namespace LTSefpBL.Model
{
    [Serializable]
    public class Contribution
    {
        public int Id { get; set; }
        public string Name { get; }

        public double Money { get; }

        public float Rate { get; }

        public double Month { get; }

        public string Formula { get; }

        public object Key { get; set; }

        public double Res { get; set; }
        public Contribution(string name) : this(name, "", 0, 0, 0) { }
        public Contribution(string name, string formula, double money, float rate, double month)
        {
            #region Проверка
            if (money <= 0)
            {
                throw new ArgumentNullException("Where are your MONEY?))", nameof(money));
            }
            if (rate <= 0)
            {
                throw new ArgumentNullException("Its not credit:(", nameof(rate));
            }
            if (month <= 0)
            {
                throw new ArgumentNullException("Isn't it too fast", nameof(month));
            }
            #endregion
            Name = name;
            Formula = formula;
            Money = money;
            Rate = rate;
            Month = month;
            double i = Calc(formula, money, rate, month);
            Res = i;
        }

        public static double Calc(string formula, double money, float rate, double month)

        {
            float time = 30.4167f;
            int dperYear = 365;
            int year = DateTime.Now.Year;
            if (year % 4 == 0 && year % 100 != 0 && year % 400 == 0)
            {
                dperYear = 366;
            }
            double i = 0;

            if (formula == "c")
            {
                int y = dperYear * 100;
                double s = (1 + (rate * time / y));
                double v = Math.Pow(s, month);
                i = Math.Round(money * v);
            }
            else if (formula == "s")
            {
                int y = dperYear * 100;
                double mt = month * time;
                double s = (1 + (rate * mt / y));
                i = Math.Round(money * s);
            }

            return i;

        }
    }
}
