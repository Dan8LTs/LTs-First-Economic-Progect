#region Libraries
using System;
using LTSefpBL.Controller;
using LTSefpBL.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Linq;
#endregion


namespace LTSefp.CMD
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string loc;
            var culture = CultureInfo.CurrentCulture;
            if (culture.ToString() == "ru-RU")
            {
                loc = "ru";
            }
            else
            {
                loc = "en";
            }

            var resourceManager = new ResourceManager("LTSefp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("Name", culture));
            string name = Console.ReadLine();

            var userController = new UserController(name);
            var costaController = new CostsAController(userController.CurrentUser);
            var contrController = new ContributionController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("Income Type", culture));
                var type = Console.ReadLine();

                var birthDate = ParseDateTime(resourceManager, culture);

                int earning = 0;

                if (loc == "ru")
                {
                    earning = ParseInt("ваш заработок", culture, resourceManager);
                }
                else
                {
                    earning = ParseInt("your earning", culture, resourceManager);
                }

                userController.SetNewUserData(type, birthDate, earning);

            }

            string currency = "R";
            Console.WriteLine(resourceManager.GetString("Currency", culture));
            var cu = Console.ReadKey();
            Console.WriteLine();
            if (cu.Key == ConsoleKey.C)
            {
                Console.WriteLine(resourceManager.GetString("CurrencyName", culture));
                var readl = Console.ReadLine();
                switch (readl)
                {
                    case "dollar":
                        currency = "$";
                        break;
                    case "доллар":
                        currency = "$";
                        break;
                    case "euro":
                        currency = "E";
                        break;
                    case "евро":
                        currency = "E";
                        break;
                    default:
                        if (readl.Length == 0)
                        {
                            break;
                        }
                        else if (readl.Length == 1)
                        {
                            currency = readl;
                        }
                        else
                        {
                            currency = readl.Substring(0, 2).ToUpper();
                        }
                        break;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(userController.CurrentUser.Hello(resourceManager, culture));

                Console.WriteLine(resourceManager.GetString("Do", culture));
                Console.WriteLine(resourceManager.GetString("Costs", culture));
                Console.WriteLine(resourceManager.GetString("Contrib", culture));
                Console.WriteLine(resourceManager.GetString("Cred", culture));
                Console.WriteLine(resourceManager.GetString("Quit", culture));


                var key = Console.ReadKey();
                Console.WriteLine();

                #region F   
                if (key.Key == ConsoleKey.F)
                {
                    Console.Clear();
                    Console.WriteLine(resourceManager.GetString("If you want", culture));
                    Console.WriteLine(resourceManager.GetString("BeforeCosts", culture));
                }

                var coll = new List<int>();

                while (key.Key == ConsoleKey.F)
                {
                    var strin = Console.ReadLine();
                    if (strin != "cont")
                    {
                        Console.WriteLine(resourceManager.GetString("CostName", culture));
                        var cost = Console.ReadLine();
                        if (cost == "cont") { break; }
                        var price = 0;

                        if (loc == "ru")
                        {
                            price = ParseInt("цену", culture, resourceManager);
                        }
                        else
                        {
                            price = ParseInt("price", culture, resourceManager);
                        }


                        coll.Add(price);
                        var ens = coll.Sum();

                        var c = EnterCostsA(cost, price);

                        costaController.Add(c.Costs, c.Price);

                        Console.Clear();
                        Console.WriteLine(resourceManager.GetString("If you want", culture));
                        Console.WriteLine(resourceManager.GetString("BeforeCosts", culture));
                        Console.WriteLine();
                        foreach (var item in costaController.Cost.Cost)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value} {currency}");
                        }

                        var ern = userController.CurrentUser.Earning - ens;
                        if (ern >= 0)
                        {
                            Console.WriteLine();
                            string income = resourceManager.GetString("Income", culture);
                            Console.WriteLine(income + ern + currency);
                        }
                        else
                        {
                            Console.WriteLine("Вы ещё добъётесь успеха, вы в минусе ", ern);
                        }

                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }

                }

                #endregion

                #region G
                if (key.Key == ConsoleKey.G)
                {
                    Console.Clear();
                    Console.WriteLine(resourceManager.GetString("Formula", culture));
                    string formula = Console.ReadLine();
                    if (formula == "c")
                    {
                        Console.WriteLine(resourceManager.GetString("ContrName", culture));
                        string ContrName = Console.ReadLine();

                        Console.WriteLine(resourceManager.GetString("InitialAmount", culture));
                        int money = Int32.Parse(Console.ReadLine());

                        Console.WriteLine(resourceManager.GetString("Rate", culture));
                        float rate = float.Parse(Console.ReadLine());

                        Console.WriteLine(resourceManager.GetString("Month", culture));
                        double month = double.Parse(Console.ReadLine());

                        double res = Contribution.Calc(formula, money, rate, month);
                        var q = EnterContrA(ContrName, formula, money, rate, month, res);
                        contrController.Add(q.Contribution, q.Money);
                        Console.Clear();

                        foreach (var item in contrController.Contrib.Contributions)
                        {
                            Console.WriteLine($"\t{item.Key.Name} - {item.Value} {currency}");
                            Console.WriteLine($"\t{item.Key.Month} - {item.Key.Money} {currency}");
                            Console.WriteLine();
                        }
                    }
                    else if (formula == "s")
                    {
                        Console.WriteLine(resourceManager.GetString("CostName", culture));
                        string namec = Console.ReadLine();

                        Console.WriteLine(resourceManager.GetString("InitialAmount"), culture);
                        int money = Int32.Parse(Console.ReadLine());

                        Console.WriteLine(resourceManager.GetString("Rate", culture));
                        float rate = float.Parse(Console.ReadLine());

                        Console.WriteLine(resourceManager.GetString("Month", culture));
                        double month = double.Parse(Console.ReadLine());

                        double res = Contribution.Calc(formula, money, rate, month);
                        var q = EnterContrA(namec, formula, money, rate, month, res);
                        contrController.Add(q.Contribution, q.Money);
                        Console.WriteLine(res);

                        foreach (var item in contrController.Contrib.Contributions)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value} {currency}");
                        }
                    }
                    else
                    {
                        break;
                    }


                }
                #endregion
                Console.WriteLine();
                #region H
                if (key.Key == ConsoleKey.H)
                {
                    Console.WriteLine(resourceManager.GetString("InitialAmount", culture));
                    double InAm = double.Parse(Console.ReadLine());

                    Console.WriteLine(resourceManager.GetString("Month", culture));
                    int month = Int32.Parse(Console.ReadLine());

                    Console.WriteLine(resourceManager.GetString("Rate", culture));
                    double rate = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(resourceManager.GetString("FirstContr", culture));
                    int fC = Int32.Parse(Console.ReadLine());

                    string[] Arr = Credit.monthAmount(InAm, rate, month, fC);
                    Console.WriteLine();
                    Console.WriteLine(Arr[0] + currency);
                    Console.WriteLine(Arr[1] + currency);

                }

                #endregion
                Console.WriteLine();
                if (key.Key == ConsoleKey.Q)
                {
                    Quit();
                }
                Console.ReadKey();
            }
        }


        private static (Costs Costs, double Price) EnterCostsA(string cost, int price)
        {
            var cos = new Costs(cost, price);

            return (Costs: cos, price);
        }

        private static DateTime ParseDateTime(ResourceManager resMan, System.Globalization.CultureInfo culture)
        {
            DateTime birthDate;

            Console.WriteLine(resMan.GetString("Birthdate", culture));
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("NotBithdate");
                }

            }
            return birthDate;

        }

        public static int ParseInt(string name, System.Globalization.CultureInfo culture, ResourceManager resMan)
        {
            while (true)
            {
                Console.WriteLine(resMan.GetString("Enter", culture) + " " + name + resMan.GetString(":", culture));
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(resMan.GetString("NotName", culture), name);
                }
            }
        }

        public static (Contribution Contribution, double Money) EnterContrA(string contr, string formula, double money, float rate, double month, double res)
        {
            var co = new Contribution(contr, formula, money, rate, month);

            return (Contribution: co, res);
        }

        public static void Quit()
        {
            Console.Clear();
            Console.WriteLine("Спасибо:)");
            Console.WriteLine("Мы стараемся для вас)");
            while (true) { }
        }
    }
}
