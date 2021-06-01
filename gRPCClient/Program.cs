using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using gRPCServer.Protos;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");


            //AntiVirus
            var client = new AntiVirus.AntiVirusClient(channel);

            using (var call = client.GetAllAsync(new AntiVirusRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentAntiVirus = call.ResponseStream.Current;
                    Console.WriteLine($"{currentAntiVirus.Name} *** {currentAntiVirus.OS}");
                }
            }


            //Calcaulator
            var client1 = new Calcaulator.CalcaulatorClient(channel);
            var sumRequest = new SumRequest
            {
                FirstNumber = 2,
                SecondNumber = 1
            };
            var call1 = client1.Sum(new SumRequest
            {
                FirstNumber = 1,
                SecondNumber = 2
            });

            Console.WriteLine($"\n************************************\nSum:{call1.Sum}");

            Console.ReadKey();
        }
    }
}
