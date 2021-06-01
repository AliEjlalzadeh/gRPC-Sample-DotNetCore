using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using gRPCServer.Protos;

namespace gRPCServer.Services
{
    public class AntiVirusService : AntiVirus.AntiVirusBase
    {
        public async override Task GetAllAsync(AntiVirusRequest request, IServerStreamWriter<AntiVirusResponse> responseStream, ServerCallContext context)
        {
            var antiViruses = new List<AntiVirusResponse>
            {
                new AntiVirusResponse
                {
                    Name = "ESET",
                    OS = "Windows"
                },
                new AntiVirusResponse()
                {
                    Name = "MACAFE",
                    OS="Windows"
                },
                new AntiVirusResponse()
                {
                    Name = "Padvish",
                    OS="Windows"
                },
                new AntiVirusResponse()
                {
                    Name = "Bitbaan",
                    OS="Android"
                }
            };

            foreach (var antiVirus in antiViruses)
            {
                await responseStream.WriteAsync(antiVirus);
                Thread.Sleep(2000);
            }
        }
    }
}
