using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chapter7
{
    class Program
    {
        static string s = "Hello";

        static void Main(string[] args)
        {
            IEnumerator rator = s.GetEnumerator();

            while (rator.MoveNext())
            {
                char c = (char)rator.Current;
                Console.Write(c + ".");
            }
        }
    }
}
