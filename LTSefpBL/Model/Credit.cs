using System;

namespace LTSefpBL.Model
{
    public class Credit
    {
        public int Id { get; set; }
        public double InitialAmount { get; }
        public double Rate { get; }
        public int Month { get; }
        public int FirstContr { get; }

        public Credit(double initialAmount, double rate, int month, int firstContr)
        {
            #region Проверка
            if (initialAmount <= 0)
            {
                throw new ArgumentNullException("Начальная сумма должна быть больше 0.", nameof(initialAmount));
            }
            if (rate <= 0)
            {
                throw new ArgumentNullException("Процентная ставка должна быть больше 0", nameof(rate));
            }
            if (month <= 0)
            {
                throw new ArgumentNullException("Срок должен быть больше 0 месяцев", nameof(month));
            }

            #endregion

            InitialAmount = initialAmount;
            Rate = rate;
            Month = month;
            FirstContr = firstContr;
        }

        public static string[] monthAmount(double initialAmount, double rate, int month, int firstContr)
        {
            var first = initialAmount / 100 * firstContr;
            var amount = initialAmount - first;
            double a = 1 + (rate / 1200);
            double k = ((Math.Pow(a, month)) * (a - 1)) / ((Math.Pow(a, month)) - 1);
            var c = Math.Round(k * amount);
            var allAm = first + c * month;
            string[] RetArray = new string[2];
            RetArray[0] = $"Monthly payment - { c.ToString()}";
            RetArray[1] = $"Full amount - {allAm.ToString()}";
            return RetArray;
        }

        
    }
}
