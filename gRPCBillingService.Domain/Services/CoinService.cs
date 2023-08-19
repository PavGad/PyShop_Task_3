using gRPCBillingService.Domain.Interfaces;
using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Persistence.Interfaces;
using gRPCBillingService.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Domain.Services
{
    public class CoinService : ICoinService
    {
        private ICoinRepository _coinRepository;
        private IUserRepository _userRepository;
        public CoinService(ICoinRepository coinRepository, IUserRepository userRepository)
        {
            _coinRepository = coinRepository;
            _userRepository = userRepository;
        }

        public void EmitCoins(long count)
        {
            var users = _userRepository.GetUsers().ToList();
            if (count < users.Count()) 
            {
                throw new ArgumentException("Coins amount can't bew less than users amount");
            }
            DistributeCoins(count, users);
        }

        public CoinDTO GetCoinWithLongestHistory()
        {
            var res = _coinRepository.GetCoins().MaxBy(x => x.HistoryLenth);
            ArgumentNullException.ThrowIfNull(res);
            return new CoinDTO(res.Id, res.History, res.HistoryLenth);
        }

        public void MoveCoins(long count, string source, string destination)
        {
            _coinRepository.MoveCoins(count, source, destination);
        }


        private void DistributeCoins(long coins, List<User> usersList)
        {
            var users = usersList.OrderBy(o => o.Rating);
            long coinsLeft = coins;
            long totalRating = users.Sum(a => a.Rating);

            foreach (var item in users)
            {
                double coefficient = (double)coinsLeft / totalRating;
                long portion = (int)Math.Round(item.Rating * coefficient);
                portion = portion < 1 ? 1 : portion;
                portion = portion > coinsLeft ? coinsLeft : portion;
                _coinRepository.EmitCointToUser(item, portion);
                coinsLeft -= portion;
                totalRating -= item.Rating;
            }
        }


        
    }
}
