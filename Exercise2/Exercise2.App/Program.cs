using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Exercise2.Entities;
using Exercise2.Infrastructure;

namespace Exercise2.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();

            //var u = new User { Name = "Bla", 
            //    ImageUrl = new Uri("http://www.iconarchive.com/show/harmonia-pastelis-icons-by-raindropmemory/hp-girl-icon.html"), 
            //    UserType = UserType.Regular};

            //userRepository.Insert(u);
            var users = userRepository.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
