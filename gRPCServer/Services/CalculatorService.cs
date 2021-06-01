using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using gRPCServer.Protos;

namespace gRPCServer.Services
{
    public class CalculatorService : Calcaulator.CalcaulatorBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            var sum = request.FirstNumber + request.SecondNumber;

            var sumResponse = new SumResponse
            {
                Sum = sum
            };

            return Task.FromResult(sumResponse);
        }
    }
}
