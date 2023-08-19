using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Persistence.Entities
{
    public class Coin
    {
        public long Id { get; set; }
        private List<User> _ownersHistory = new List<User>();

        [NotMapped]
        public int HistoryLenth
        {
            get { return _ownersHistory.Count(); }
        }

        [NotMapped]
        public string History
        {
            get { return string.Join(",", _ownersHistory.Select(t => t.Name)); }
        }

        public void AddHistoryStamp(User user)
        {
            _ownersHistory.Add(user);
        }

        public Coin()
        {
              
        }

        public Coin(long id)
        {
            Id = id;
        }
    }
}
