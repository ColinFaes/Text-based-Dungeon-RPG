using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.Write("Enter your character's name: ");
                string playerName = Console.ReadLine();
