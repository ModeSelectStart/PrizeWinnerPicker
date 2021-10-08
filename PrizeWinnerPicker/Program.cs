using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrizeWinnerPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable setup
            var read = new StreamReader("Data/subtember.txt");
            var gen = new Random();
            var names = new List<string>();
            var inputfile = read.ReadLine();
            var numEntries = new Dictionary<string, int>();
            //Reading from file
            while (inputfile!= null)
            {
                names.Add(inputfile);
                inputfile = read.ReadLine();
            }

            //SHOW THE WINNER
            Console.WriteLine(names[gen.Next(names.Count)]);

            //Choose how many entries each person put in
            Console.WriteLine("Press Enter to get Number of Entries per person");
            Console.ReadLine();
            foreach(var n in names)
            {
                if (numEntries.ContainsKey(n))
                {
                    numEntries[n]++;
                }
                else
                {
                    numEntries.Add(n, 1);
                }
            }
            var orderedEntries = (
                from entries in numEntries
                orderby entries.Value*-1
                select new
                {
                    entries.Key,
                    entries.Value
                });
            //Show number of entries each person put in
            foreach(var o in orderedEntries)
            {
                Console.WriteLine($"{o.Key}:\t{o.Value}");
            }
            Console.ReadLine();
        }
    }
}
