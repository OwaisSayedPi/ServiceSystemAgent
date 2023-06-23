using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Net.Http;
using Entity;
using System.Net.Http.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Page p = new MainMenu();
                p.DisplayMenu();
            } while (true);

        }
    }
}
