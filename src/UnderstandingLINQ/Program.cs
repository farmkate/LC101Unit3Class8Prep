using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>() {
                new Car() { VIN="A1", Make = "BMW", Model= "550i", StickerPrice=55000, Year=2009},
                new Car() { VIN="B2", Make="Toyota", Model="4Runner", StickerPrice=35000, Year=2010},
                new Car() { VIN="C3", Make="BMW", Model = "745li", StickerPrice=75000, Year=2008},
                new Car() { VIN="D4", Make="Ford", Model="Escape", StickerPrice=25000, Year=2008},
                new Car() { VIN="E5", Make="BMW", Model="55i", StickerPrice=57000, Year=2010}
            };

            // LINQ query syntax

            var bmws = from car in myCars
                where car.Make == "BMW"
                && car.Year == 2010
                select car;

            Console.WriteLine("\nLINQ query syntax: filtering a collection");
            foreach (var car in bmws)
            {
                Console.WriteLine("{0} {1}", car.Model, car.VIN);
            }

            // LINQ method syntax

            var bmws2 = myCars.Where(car => car.Make == "BMW" && car.Year == 2010);

            Console.WriteLine("\nLINQ method syntax: filtering a collection");
            foreach (var car in bmws2)
            {
                Console.WriteLine("{0} {1}", car.Model, car.VIN);
            }

            // LINQ query syntax - ordered list of cars

            var orderedCars = from car in myCars
                orderby car.Year descending
                select car;

            Console.WriteLine("\nLINQ query syntax: ordering the collection");
            foreach (var car in orderedCars)
            {
                Console.WriteLine("{0} {1} {2}", car.Year, car.Model, car.VIN);
            }

            // LINQ method syntax - ordered list of cars

            var orderedCars2 = myCars.OrderByDescending(car => car.Year);

            Console.WriteLine("\nLINQ method syntax: ordering the collection");
            foreach (var car in orderedCars2)
            {
                Console.WriteLine("{0} {1} {2}", car.Year, car.Model, car.VIN);
            }

            // LINQ method syntax - grabbing the first item in the list

            var firstBMW = myCars.First(car => car.Make == "BMW");

            Console.WriteLine("\nLINQ method syntax: fetching the first item");
            Console.WriteLine("{0} {1} {2}", firstBMW.Year, firstBMW.Model, firstBMW.VIN);

            // LINQ method syntax - grabbing the first item in an ordered list

            var firstNewestBMW = myCars.OrderByDescending(car => car.Year)
                .First(car => car.Make == "BMW");

            Console.WriteLine("\nLINQ method syntax: ordering the collection then fetching the first item");
            Console.WriteLine("{0} {1} {2}", firstNewestBMW.Year, firstNewestBMW.Model, firstNewestBMW.VIN);

            // LINQ method syntax - determining if a criteria applies to all items in a list

            Console.WriteLine("\nLINQ method syntax: Determining if a criteria applies to all items in a list");
            Console.WriteLine(myCars.TrueForAll(car => car.Year > 2012)); //false
            Console.WriteLine(myCars.TrueForAll(car => car.Year > 2009)); //false
            Console.WriteLine(myCars.TrueForAll(car => car.Year > 2007)); //true

            // LINQ method syntax - iterating over each item with a function

            Console.WriteLine("\nLINQ method syntax: Iterating over each item with a function");
            myCars.ForEach(car => Console.WriteLine("{0} {1:C}", car.VIN, car.StickerPrice));

            /*
            // equivalent to:
            foreach (Car car in myCars) {
                Console.WriteLine("{0} {1:C}", car.VIN, car.StickerPrice)
            }
            */

            // LINQ method syntax - performing an operation on each item with a function

            Console.WriteLine("\nLINQ method syntax: Performing an operation on each item with a function");
            myCars.ForEach(car => car.StickerPrice -= 3000);
            myCars.ForEach(car => Console.WriteLine("{0} {1:C}", car.VIN, car.StickerPrice));

            // LINQ method syntax - determining if an item is in a list based on some criteria

            Console.WriteLine("\nLINQ method syntax - determining if an item is in a list based on some criteria");
            bool exists = myCars.Exists(car => car.Model == "745li");
            Console.WriteLine("Is the 745li in the list? {0}", exists);

            // LINQ method syntax - using an aggregate method to sum sticker prices with a function

            Console.WriteLine("\nLINQ method syntax - using an aggregate method to sum sticker prices with a function");
            double sum = myCars.Sum(car => car.StickerPrice);
            Console.WriteLine("Sum of all sticker prices: {0}", sum);

            // What is the type of myCars?

            Console.WriteLine("\nWhat is the type of myCars?");
            Console.WriteLine(myCars.GetType());

            // What is the return type of a LINQ OrderBy*() method?

            Console.WriteLine("\nWhat is the return type of a LINQ OrderBy*() method (e.g., OrderByDescending())?");
            Console.WriteLine(orderedCars.GetType());

            // What is the return type of a LINQ Where() method?

            Console.WriteLine("\nWhat is the return type of a LINQ Where() method?");
            Console.WriteLine(bmws2.GetType());

            // Projecting existing data into a new (anonymous) data type

            Console.WriteLine("\nWhat is the return type of a LINQ projection?");
            var newCars = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2010
                       select new { car.Make, car.Model };

            Console.WriteLine(newCars.GetType());


            Console.ReadLine();
        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }
}
