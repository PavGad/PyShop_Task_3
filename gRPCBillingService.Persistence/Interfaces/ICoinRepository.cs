using gRPCBillingService.Persistence.Entities;

namespace gRPCBillingService.Persistence.Interfaces
{
    public interface ICoinRepository
    {
        public IEnumerable<Coin> GetCoins();
        public void MoveCoins(long count, string source, string destination);
        public void EmitCointToUser(User user, long coinAmount);
    }
}
