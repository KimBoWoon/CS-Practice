using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(feetToInch(12));
            Console.WriteLine(feetToInch(100));
        }

        static int feetToInch(int feet)
        {
            return feet * 12;
        }
    }
}
