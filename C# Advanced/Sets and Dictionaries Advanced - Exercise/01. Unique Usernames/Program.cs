﻿using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> people = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                people.Add(name);
            }

            foreach (var name in people)
            {
                Console.WriteLine(name);
            }
        }
    }
}
