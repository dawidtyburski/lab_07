using System;
using System.Collections.Generic;
using System.Linq;


namespace lab_07
{
    class Program
    {
        static void Main(string[] args)
        {

            ProjectDBContext db = new ProjectDBContext();
            var per = from p in db.Persons
                        select p;
            foreach(var item in per)
            {
                Console.WriteLine($"{item.Name} {item.Surname}");
            }
        }
    }
}
