using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Domain.Interfaces
{
    public interface ICoinService
    {
        public void EmitCoins(long count);
        public void MoveCoins(long count, string source, string destination);
        public CoinDTO GetCoinWithLongestHistory();
    }
}
