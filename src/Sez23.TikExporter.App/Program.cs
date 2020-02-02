using System;
using Sez23.TikExporter;

namespace Sez23.TikExporter.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var api = new Api.ApiService();
            api.Read();


            Console.WriteLine("TikExporter!");
        }
    }
}
