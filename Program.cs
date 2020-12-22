using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TcpControl
{
    class Program
    {
        /// TCP Listener, Private
        private static TcpListener _server = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LSAM!");
            // TestProgram();

            // Set the TcoListener on port 2020
            Int32 port = 2020;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            //TcpListener server = new TcpListener(port)
            _server = new TcpListener(localAddr, port);

        }  

        static void TestProgram()
        {
            var name = Console.ReadLine();
            var date = DateTime.Now;
            
            Console.WriteLine($"\nHello, {name}, on {date} at {date:t}!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
