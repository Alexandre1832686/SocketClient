using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Configuration;
using System.Text.Json;

namespace socketClient
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {

            string monPersoSéréalisé = PrepareObj();
            Connect_Send_And_Close(monPersoSéréalisé);
        }

        static void Connect_Send_And_Close(string message)
        {
            // data buffer for incoming data 
            byte[] bytes = new byte[1024];

            // connect to a Remote device 
            try
            {
                // Establish the remote end point for the socket 
                IPHostEntry ipHost = Dns.Resolve("127.0.0.1");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

                Socket sender = new Socket(AddressFamily.InterNetwork,
                                            SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint 

                sender.Connect(ipEndPoint);

                Console.WriteLine("Socket connected to {0}",
                sender.RemoteEndPoint.ToString());

               

                byte[] msg = Encoding.ASCII.GetBytes(message + "<theend>");

                // Send the data through the socket 
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device 
                int bytesRec = sender.Receive(bytes);

                Console.WriteLine("The Server says : {0}",
                                    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
        }

        static string PrepareObj()
        {
            
            Perso monperso = new Perso("popo", 15, "gars");
            string jsonString = JsonSerializer.Serialize(monperso);
            Console.WriteLine(jsonString);
            Console.ReadLine();
            return jsonString;
                
        }
    }
}
   