using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELDYN.Misc
{
    public static class UserWriter
    {
        public static void WriteToUser(String text)
        {
            Console.WriteLine(text);
        }
        public static void WriteToUserAndCrash(String text)
        {
            Console.WriteLine(text);
            Environment.Exit(-1);
        }
    }
}
