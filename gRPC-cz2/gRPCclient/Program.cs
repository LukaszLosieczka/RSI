using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MyData;

namespace gRPCclient
{
    class Program
    {
        //static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Starting gRPC Client");
        //    using var channel = GrpcChannel.ForAddress("http://localhost:5001");
        //    var client = new GrpcService.GrpcServiceClient(channel);
        //    Console.WriteLine("Enter the name :     ");
        //    string str = Console.ReadLine();
        //    int val = 21;
        //    var reply = await client.GrpcProcAsync(
        //                      new GrpcRequest { Name = str, Age = val });
        //    Console.WriteLine("From Server: " + reply.Message);
        //    Console.WriteLine("From Server: " + val + " years = " + reply.Days + " days" );
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadKey();
        //    channel.ShutdownAsync().Wait();
        //}

        //static async Task Main(string[] args)
        //{
        //    MyData.MyData.Info();
        //    Console.WriteLine("/////////////////////////");
        //    Console.WriteLine("Starting gRPC Client");
        //    using var channel = GrpcChannel.ForAddress("http://localhost:5001");
        //    var client = new GrpcService.GrpcServiceClient(channel);
        //    Console.WriteLine("Enter the name :     ");
        //    string str = Console.ReadLine();
        //    Console.WriteLine("Enter age :     ");
        //    int val = int.Parse(Console.ReadLine());
        //    var reply = await client.GrpcProcAsync(
        //                      new GrpcRequest { Name = str, Age = val });
        //    Console.WriteLine("From Server: " + reply.Message);
        //    Console.WriteLine("From Server: " + val + " years = " + reply.Days + " days");
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadKey();
        //    channel.ShutdownAsync().Wait();
        //}

        static async Task Main(string[] args)
        {
            MyData.MyData.Info();
            Console.WriteLine("/////////////////////////");
            Console.WriteLine("Starting gRPC Client - Calculate PI");
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new CalculatePi.CalculatePiClient(channel);
            Console.WriteLine("Enter number of digits :     ");
            int val = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your number :     ");
            double number = double.Parse(Console.ReadLine());
            var reply = await client.CalculateAsync(new CalculatePiRequest {Digits=val, Number=number });
            Console.WriteLine("From Server: " + reply.Result);
            Console.WriteLine("From Server is your number greater than PI: " + reply.IsGreater);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
