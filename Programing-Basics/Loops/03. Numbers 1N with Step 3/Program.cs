﻿using System;

namespace _03._Numbers_1N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
