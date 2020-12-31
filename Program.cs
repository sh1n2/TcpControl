using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace TcpControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LSAM Data Transciever Test Program!");
            
            if(args.Length < 2)
            {
                Console.WriteLine("Usage : {0} <Bind IP> <Port> ", Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];
            int bindPort = int.Parse(args[1]);
            TcpListener server = null;

            try
            {
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAddress);

                server.Start();

                Console.WriteLine($"[Server] {bindIp}:{bindPort} Server Start...");

                while(true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Client Connect Success: {((IPEndPoint)client.Client.RemoteEndPoint).ToString()}");

                    NetworkStream stream = client.GetStream();

                }
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }  

        // Test Program
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