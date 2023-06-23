using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class GetReader
    {
        public static int GetInteger(string msg)
        {
            int output = 0;
            bool TryAgain = false;
            while (!TryAgain)
            {
                TryAgain = int.TryParse(Console.ReadLine(), out output);
                if (!TryAgain)
                {
                    Console.WriteLine(msg);
                }
            }
            return output;
        }

        public static string GetString(string msg)
        {
            string output = "";
            bool TryAgain = false;
            while (!TryAgain)
            {
                output = Console.ReadLine();
                TryAgain = true;
                if(output == "")
                {
                    TryAgain = false;
                    Console.WriteLine(msg);
                }
            }
            return output;
        }
    }
}
