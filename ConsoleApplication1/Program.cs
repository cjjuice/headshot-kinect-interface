using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int local_port = 9000;
            TcpListener listener = new TcpListener( local_port);
            Console.WriteLine("Starting listener");
            listener.Start();


           

            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream))
                {
                    /*Socket soc = listener.AcceptSocket(); // blocks
                    Console.WriteLine("Connection accepted");

                    Stream s = new NetworkStream(soc);
                    String str = "Hello, world!\n";
                    byte[] bytes = new byte[str.Length * sizeof(char)];
                    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

                    s.Write(bytes, 0, bytes.Length);
                    s.Close();
                    Console.WriteLine("Closing socket");
                    soc.Close();*/

                    writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
                    writer.WriteLine("Upgrade: WebSocket");
                    writer.WriteLine("Connection: Upgrade");
                    writer.WriteLine("WebSocket-Origin: http://localhost:8080");
                    writer.WriteLine("WebSocket-Location: ws://localhost:8181/websession");
                    writer.WriteLine("");


                    reader.ReadLine();

                    writer.WriteLine("Hello, World!");

                }

            }
        }
    }
}

