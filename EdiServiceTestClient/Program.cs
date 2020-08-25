using EdiService;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace EdiServiceTestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var request = new HelloRequest() { Name = "Steve" };

            var reply = await client.SayHelloAsync(request);

            Console.WriteLine(reply.Message);

            Console.ReadLine();
        }
    }
}
