using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestService service = new RequestService();
            service.Start();

            Console.ReadKey(false);
        }
    }
}
