using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCR.Utils
{
    public static class Input
    {
        public static string[] GetTestInput()
        {
            return File.ReadAllLines("../../../InputT.txt");
        }

        public static string[] GetRealInput()
        {
            return File.ReadAllLines("../../../Input.txt");
        }
    }
}
