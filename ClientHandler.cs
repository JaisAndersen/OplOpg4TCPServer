using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace oplopg4tcpserver
{
    public class ClientHandler
    {
        public static void HandleClient(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            bool isRunning = true;

            while (isRunning)
            {
                string? message = reader.ReadLine();
                Console.WriteLine(message);
                if (message == "Random")
                {
                    writer.WriteLine("Input Numbers");
                    writer.Flush();
                    string? dicePick = reader.ReadLine();
                    string[] dicePickSplit = dicePick.Split(' ');
                    if (dicePick != null)
                    {
                        int dicePickParsedFirst = Int32.Parse(dicePickSplit[0]);
                        int dicePickParsedSecond = Int32.Parse(dicePickSplit[1]);
                        Random random = new Random();
                        writer.WriteLine(random.Next(dicePickParsedFirst, dicePickParsedSecond + 1));
                        writer.Flush();
                    }
                }
                else if (message == "Add")
                {
                    writer.WriteLine("Input Numbers");
                    writer.Flush();
                    string? addPick = reader.ReadLine();
                    string[] addPickSplit = addPick.Split(' ');
                    if (addPick != null)
                    {
                        int addPickParsedFirst = Int32.Parse(addPickSplit[0]);
                        int addPickParsedSecond = Int32.Parse(addPickSplit[1]);
                        writer.WriteLine(addPickParsedFirst + addPickParsedSecond);
                        writer.Flush();
                    }
                }
                else if (message == "Substract")
                {
                    writer.WriteLine("Input Numbers");
                    writer.Flush();
                    string? subPick = reader.ReadLine();
                    string[] subPickSplit = subPick.Split(' ');
                    if (subPick != null)
                    {
                        int subPickParsedFirst = Int32.Parse(subPickSplit[0]);
                        int subPickParsedSecond = Int32.Parse(subPickSplit[1]);
                        writer.WriteLine(subPickParsedFirst - subPickParsedSecond);
                        writer.Flush();
                    }
                }
                else
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
            }
            client.Close();
        }
    }
}
