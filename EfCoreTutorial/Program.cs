using System;
using EfCoreTutorial.Models;
using System.Linq;

namespace EfCoreTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDBContext())
            //compare to "Get all users"
            {
                var customers = db.Customers
                 .Where(c => c.Active == true)
                 .OrderBy(c => c.Name)
                 .ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                }

                //compare to "GetByPrimaryKey"

                //var id = 5;
                //var macys = db.Customers.Find(id);
                //Console.WriteLine("PK result = " + macys.Name);

                //compare to "insert user"
                var insCustomer = new Customer()
                {
                    Id = 0,
                    Name = "Kroger",
                    Active = true,
                    DateCreated = DateTime.Now,
                    Phone = "555-123-4567"

                };

                var insCustomer1 = new Customer()
                {
                    Id = 0,
                    Name = "Meijer",
                    Active = true,
                    DateCreated = DateTime.Now,
                    Phone = "555-555-1234"
                };

                var order1 = new Order()
                {
                    Date = DateTime.Now,
                    Description = "My First Order",
                    CustomerId = db.Customers.FirstOrDefault(c => c.Name == "Meijer").Id,
                    Total = 5000
                };
                var order2 = new Order()
                {
                    Date = DateTime.Now,
                    Description = "My Second Order",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "P&G").Id,
                    Total = 5500
                };
                var order3 = new Order()
                {
                    Date = DateTime.Now,
                    Description = "My Third Order",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Costco").Id,
                    Total = 6000
                };
                var order4 = new Order()
                {
                    Date = DateTime.Now,
                    Description = "My Fourth Order",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Intel").Id,
                    Total = 6500
                };
                var order5 = new Order()
                {
                    Date = DateTime.Now,
                    Description = "My Fifth Order",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Asus").Id,
                    Total = 7000
                };
                db.Orders.Add(order1);
                db.Orders.Add(order2);
                db.Orders.Add(order3);
                db.Orders.Add(order4);
                db.Orders.Add(order5);

                var orders = db.Orders.ToList();
                orders.ForEach(o => Console.WriteLine(o));

                var o1 = db.Orders.Find(36);
                Console.WriteLine($"Find by PK: {o1}");

                var orders1 = db.Orders
                 .Where(o => o.Total > 5000)
                 .OrderByDescending(o => o.Total)
                 .ToList();
                foreach (var o in orders1)
                {
                    Console.WriteLine("X"+o);
                }                                              

                var custname = "Asus";
                var orders2 = db.Orders
                    .Where(o => o.Customer.Name == custname)
                    .Sum(o => o.Total);
                Console.WriteLine($"The Sales for {custname} is : {orders2}");
                
             
                var haskroger = db.Customers.Any(c => c.Name == "Kroger");
                if (!haskroger)
                {
                    db.Customers.Add(insCustomer);
                }
                else
                    Console.WriteLine("Cannot duplicate user");

                //compare to "update user"
                //var cMy = db.Customers.Find(5);
                //cMy.Name = "Macys Retail";
                //cMy.Phone = "555-321-9876";
                //compare to "delete user"
                var firstkroger = db.Customers.FirstOrDefault(c => c.Name == "Kroger");
                if (firstkroger != null)
                {
                    db.Customers.Remove(firstkroger);
                }
                db.SaveChanges();             
            }
        }
    }
}
