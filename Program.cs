using oplopg4tcpserver;
using System.Net.Sockets;
using System.Net;

Console.WriteLine("TCP Server:");
int port = 7;
TcpListener listener = new TcpListener(IPAddress.Any, port);
listener.Start();

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    Task.Run(() => ClientHandler.HandleClient(client));
}