using System;
using System.Collections.Generic;
using System.Linq;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<List<Place>> Continents = new List<List<Place>>();
                List<List<City>> Countries = new List<List<City>>();
                Random rnd = new Random();


                int p = rnd.Next(2, 6);
                for (int i = 0; i < p; i++)
                {
                    Continents.Add(new List<Place>());
                    int w = rnd.Next(2, 6);
                    for (int j = 0; j < 3; j++)
                    {
                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                Place ad = new Place(rnd);
                                Continents[i].Add(ad);
                                break;
                            case 2:
                                Area add = new Area(new Area(new Place(rnd), rnd), rnd);
                                Continents[i].Add(add);
                                break;
                        }
                    }
                }
                p = rnd.Next(2, 6);
                for (int i = 0; i < p; i++)
                {
                    int w = rnd.Next(2, 6);
                    Countries.Add(new List<City>());
                    for (int j = 0; j < 3; j++)
                    {
                        switch (rnd.Next(1, 2))
                        {
                            case 1:
                                City addd = new City(new Area(new Place(rnd), rnd), rnd);
                                Countries[i].Add(addd);
                                break;
                            case 2:
                                Megapolice adddd = new Megapolice(new City(new Area(new Place(rnd), rnd), rnd), rnd);
                                Countries[i].Add(adddd);
                                break;

                        }
                    }
                }
                while (true)
                {
                    Console.Write("Введите область: ");
                    string search = Console.ReadLine().ToString();
                    if (search == "") break;
                    Console.WriteLine("Города: ");
                    LINQsearch(search, Countries);
                    Console.WriteLine("Города: ");
                    MethodsSearch(search, Countries);
                    LINQNumber(search, Countries);
                    MethodsNumber(search, Countries);
                    LINQCount(search, Countries);
                    MethodsCount(search, Countries);
                    Console.WriteLine("Первый вывод: ");
                    LINQToGether(Continents, Countries);
                    Console.WriteLine("Второй вывод: ");
                    MethodsToGether(Continents, Countries);
                    LINQSort(Countries);
                    MethodsSort(Countries);

                }
            }
            static void LINQToGether(List<List<Place>> mass1, List<List<City>> mass2)
            {
                var j = (from s in mass1
                         from pl in s
                         select pl).Except(from s in mass2
                                           from pl in s
                                           select pl);
                foreach (var x in j)
                {
                    Console.WriteLine(x);
                }

            }
            static void MethodsToGether(List<List<Place>> mass1, List<List<City>> mass2)
            {
                var j = mass1.SelectMany(c => c.Select(c => c)).Except(mass2.SelectMany(c => c.Select(c => c)));
                foreach (var x in j)
                {
                    Console.WriteLine(x);
                }


            }
            static void LINQNumber(string search, List<List<City>> mass)
            {
                int numb = (from s in mass
                            from pl in s
                            where pl.NameOfContinetn == search
                            select pl).Count();
                Console.WriteLine($"Количество городов на континенте {search}: " + numb);

            }
            static void MethodsNumber(string search, List<List<City>> mass)
            {
                var places = mass.SelectMany(c => c.Where(c => c.NameOfContinetn == search));
                int numb = places.Select(x => x.CountOfPeople).Count();
                Console.WriteLine($"Количество городов на континенте {search}: " + numb);

            }
            static void LINQCount(string search, List<List<City>> mass)
            {
                int numb = (from s in mass
                            from pl in s
                            where pl.NameOfContinetn == search
                            select ((City)pl).CountOfPeople).Sum();
                Console.WriteLine($"Количество людей на континенте {search}: " + numb);
            }
            static void MethodsCount(string search, List<List<City>> mass)
            {
                var places = mass.SelectMany(c => c.Where(c => c.NameOfContinetn == search));
                try
                {
                    int numb = places.Select(x => ((City)x).CountOfPeople).Aggregate<int>((a, b) => a + b);
                    Console.WriteLine($"Количество людей на континенте {search}: " + numb);
                }
                catch
                {
                    Console.WriteLine($"Количество людей на континенте {search}: " + 0);
                }

            }
            static void LINQsearch(string search, List<List<City>> mass)
            {
                var continents = from s in mass
                                 from pl in s
                                 where pl.NameOfContinetn == search
                                 select pl;
                foreach (var s in continents)
                {
                    Console.WriteLine(((City)s).NameOfCity);
                }
            }
            static void MethodsSearch(string search, List<List<City>> mass)
            {
                var continents = mass.SelectMany(c => c.Where(c => c.NameOfContinetn == search));
                foreach (var s in continents)
                {
                    Console.WriteLine(((City)s).NameOfCity);
                }
            }
            static void LINQSort(List<List<City>> mass)
            {
                var continents = (from s in mass
                                  from pl in s
                                  select pl).GroupBy(c => c.countOfPeople);
                
                foreach (var s in continents)
                {
                    Console.WriteLine(s.Key +":");
                    foreach (var k in s)
                    {
                        Console.WriteLine(k);
                    }
 
                    
                }
            }
            static void MethodsSort(List<List<City>> mass)
            {
                var continents = mass.SelectMany(c => c.Where(c => c != null)).GroupBy(c => c.countOfPeople);
                foreach (var s in continents)
                {
                    Console.WriteLine(s.Key + ":");
                    foreach (var k in s)
                    {
                        Console.WriteLine(k);
                    }


                }
            }
        }
    }
}
