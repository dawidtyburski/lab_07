using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string connectionString = (@"server=(localdb)\mssqllocaldb;database=lab07db;trusted_connection=true;");

        using (BloggingContext db = new BloggingContext(connectionString))
        {
            Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

            while(connectionString != null)
            {
                Console.WriteLine("Wybor opcji");
                Console.WriteLine("1.Dodaj uzytkownika");
                Console.WriteLine("2.Pokaz uzytkownikow");
                string wybor = Console.ReadLine();

                if(wybor == "1")
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("--Dodawanie uzytkownika...");
                    Console.WriteLine("Podaj imie");
                    string imie = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko");
                    string nazwisko = Console.ReadLine();
                    Console.WriteLine("Podaj ID funkcji");
                    var roles = from r in db.Role
                                 select r;
                    foreach (var r in roles)
                    {
                        
                        Console.WriteLine($"{r.Id}. {r.Title}");
                        
                    }
                    int funkcja = Int32.Parse(Console.ReadLine());
                    var role = from ro in db.Role
                               where ro.Id == funkcja
                               select ro;

                   foreach (var ro in role)
                   {
                        db.Add(new User { Name = imie, Surname = nazwisko, Role = ro });
                   }
                   
                    db.SaveChanges();

                    Console.WriteLine("...");
                    Console.WriteLine("Uzytkownik zostal dodany...");
                    Console.WriteLine("\n");
                }
                else if(wybor == "2")
                {
                    Console.WriteLine("--Lista uzytkownikow...");

                    var users = from u in db.User
                                    //orderby u.Id
                                select u;
                    foreach (var u in users)
                        {
                                Console.WriteLine($"{u.Id}.{u.Name} {u.Surname} [{u.Role.Title}]");

                        }
                        Console.WriteLine("\n");                    
                }                                                    
                else
                {
                    Console.WriteLine("Bledny wybor");
                }
            }                      
        }
    }
}
