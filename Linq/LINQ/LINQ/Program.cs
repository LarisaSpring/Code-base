using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LinqSample sample = new LinqSample();
            sample.JoinCollections();
            Console.ReadKey();
        }
    }

    public class LinqSample
    {
        public void SortByName()
        {
            var items = CreateCollection1();
            items = items.OrderBy(x => x.Name).ToList();
            Console.WriteLine(string.Join(" , ", items.Select(x => x.Name)));
        }

        public void GroupByNameFirstLatter()
        {
            var items = CreateCollection1();
            var grouped = items.GroupBy(x => x.Name[0]);
            Console.WriteLine(string.Join(" , ", grouped.Select(x => $"key: {x.Key} - {x.Count()}")));
        }

        public void JoinCollections()
        {
            var items = CreateCollection1();
            var items2 = CreateCollection2();

            var query = from person in items
                        join pet in items2 on person.Name equals pet.Name into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.Name, subpet?.Desctiption };

            foreach (var VARIABLE in query)
            {
                Console.WriteLine(VARIABLE.Name + " " + VARIABLE.Desctiption);
            }
        }

        public List<Item> CreateCollection1()
        {
            return new List<Item>
            {
                new Item {Name = "Jonny", Count = 1},
                new Item {Name = "Billy", Count = 4},
                new Item {Name = "Wr", Count = 1},
                new Item {Name = "Fes", Count = 33},
                new Item {Name = "Rfs", Count = 1},
                new Item {Name = "WEf", Count = 3},
                new Item {Name = "FDEFD", Count = 1},
                new Item {Name = "sdfd", Count = 1},
                new Item {Name = "EFE", Count = 7}
            };
        }

        public List<Item2> CreateCollection2()
        {
            return new List<Item2>
            {
                new Item2 {Name = "Jonny", Desctiption = "sdfsdf", Count = 1},
                new Item2 {Name = "Billy", Desctiption = "sddffsdf", Count = 4}
            };
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }

    public class Item2
    {
        public string Name { get; set; }

        public string Desctiption { get; set; }

        public int Count { get; set; }
    }
}