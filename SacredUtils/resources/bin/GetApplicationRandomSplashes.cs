﻿using System;
using System.IO;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationRandomSplashes
    {
        static readonly Random Random = new Random();
        static readonly string[] Splashes = File.ReadAllLines("$SacredUtils\\conf\\splashes.txt", Encoding.UTF8);

        public static string GetRandomSplash()
        {
            return Splashes[Random.Next(0, Splashes.Length)];
        }
    }
}
