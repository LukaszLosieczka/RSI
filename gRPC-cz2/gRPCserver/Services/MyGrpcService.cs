using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace gRPCserver.Services
{
    public class MyGrpcService : GrpcService.GrpcServiceBase
    {

        public override Task<GrpcResponse> GrpcProc(GrpcRequest request, ServerCallContext context)
        {
            string msg;
            int val;

            val = request.Age * 365;
            msg = "Hello " + request.Name + " being " + request.Age + " years old.";
            return Task.FromResult(new GrpcResponse { Message = msg, Days = val });
        }
        
    }
}
