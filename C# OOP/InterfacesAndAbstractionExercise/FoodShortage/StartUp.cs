﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split();

                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string group = parts[2];

                    buyersByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    string birthdata = parts[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdata);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(line))
                {
                    continue;
                }

                IBuyer buyer = buyersByName[line];

                buyer.BuyFood();

            }

            var total = buyersByName.Values.Sum(b => b.Food);

            Console.WriteLine(total);
        }
    }
}
