using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace gRPCserver
{
    public class CalculatePiService : CalculatePi.CalculatePiBase
    {
        private readonly ILogger<CalculatePiService> _logger;

        public CalculatePiService(ILogger<CalculatePiService> logger)
        {
            _logger = logger;
        }

        public override Task<CalculatePiResponse> Calculate(CalculatePiRequest request, ServerCallContext context)
        {
            string finalResult;
            int digits = request.Digits;
            double number = request.Number;

            if (digits < 0)
                finalResult = "0";
            else
                finalResult = GetPi(digits);

            return Task.FromResult(new CalculatePiResponse
            {
                Result = finalResult,
                IsGreater = number > Math.PI
            });
        }

        private static string GetPi(int digits)
        { 
            digits++;

            uint[] x = new uint[digits * 10 / 3 + 2];
            uint[] r = new uint[digits * 10 / 3 + 2];

            uint[] pi = new uint[digits];

            for (int j = 0; j < x.Length; j++)
                x[j] = 20;

            for (int i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;

                    x[j] += carry;

                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }


                pi[i] = (x[x.Length - 1] / 10);


                r[x.Length - 1] = x[x.Length - 1] % 10; ;

                for (int j = 0; j < x.Length; j++)
                    x[j] = r[j] * 10;
            }

            var result = "";

            uint c = 0;

            for (int i = pi.Length - 1; i >= 0; i--)
            {
                pi[i] += c;
                c = pi[i] / 10;

                result = (pi[i] % 10).ToString() + result;
            }

            string finalResult = "";

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 1)
                    finalResult += ".";
                finalResult += result[i];
            }
            return finalResult;
        }

    }
}
