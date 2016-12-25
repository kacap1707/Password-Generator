using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AghasPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var coder = new Coder(80);
            Console.WriteLine(coder.Code);

            Console.ReadKey();
        }
    }
}
