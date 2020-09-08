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
            await GreeterClient();
            await ValidatorClient();

            Console.ReadLine();
        }

        private static async Task ValidatorClient()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Validator.ValidatorClient(channel);

            var request = new EdiValidationRequest() { Payload = "Edi to validate." };

            var reply = await client.ValidateEdiAsync(request);

            Console.WriteLine(reply.Message);
        }

        private static async Task GreeterClient()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var request = new HelloRequest() { Name = "Steve" };

            var reply = await client.SayHelloAsync(request);

            Console.WriteLine(reply.Message);
        }
    }
}
