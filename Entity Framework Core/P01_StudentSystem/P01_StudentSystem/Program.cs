﻿using System;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
