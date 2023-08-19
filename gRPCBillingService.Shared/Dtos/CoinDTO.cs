using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Shared.Dtos
{
    public class CoinDTO
    {
        public long Id { get; set; }
        public string History { get; set; }
        public int HistoryLength { get; set; }

        public CoinDTO(long id, string history, int historyLength)
        {
            Id = id;
            History = history;
            HistoryLength = historyLength;
        }
    }
}
