using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHP220_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Problem 1
            var helloFilter = users.Where(t => t.Password.ToLower().Contains("hello"));
            foreach (var user in helloFilter)
            Console.WriteLine(user.Name);

            //Problem 2
            users.RemoveAll(t => t.Password == t.Name.ToLower());

            //Problem 3
            users.Remove(users.First(t => t.Password.ToLower().Contains("hello")));
            
            foreach (var user in users)
            Console.WriteLine(user.Name, user.Password);
        }
    }
}
