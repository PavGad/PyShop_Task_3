using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Persistence.Interfaces;
using System.Linq;
using System.Security.Cryptography;

namespace gRPCBillingService.Persistence.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private List<Coin> _coins = new List<Coin>();
        private IUserRepository _userRepository;

        public CoinRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Coin> GetCoins()
        {
            return _coins;
        }
        public void MoveCoins(long count, string source, string destination)
        {
            var sourceUser = _userRepository.GetUsers().Where(x => x.Name == source).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(sourceUser);
            var destinationUser = _userRepository.GetUsers().Where(x => x.Name == destination).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(destinationUser);

            if (sourceUser.Amount < count)
            {
                throw new ArgumentException("Source account has unsufficient amount of coins");
            }


            var coins = sourceUser.Coins.Take((int)count).ToArray();
            foreach (var coin in coins)
            {
                sourceUser.Coins.Remove(coin);
                coin.AddHistoryStamp(destinationUser);
                destinationUser.Coins.Add(coin);
            }


        }

        private int _id = 0;
        public void EmitCointToUser(User user, long coinAmount)
        {
            for (int i = 0; i < coinAmount; i++)
            {
                Coin coin = new Coin(_id);
                coin.AddHistoryStamp(user);
                user.Coins.Add(coin);
                _coins.Add(coin);
                _id++;
            }
        }

        
    }
}

