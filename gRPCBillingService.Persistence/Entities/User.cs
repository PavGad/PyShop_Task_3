using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Persistence.Entities
{
    public class User
    {
        public string Name { get; set; }

        [NotMapped]
        public long Amount { get { return Coins.Count(); } }
        public int Rating { get; set; }

        public List<Coin> Coins { get; set; }

        public User(string name, int rating)
        {
            Name = name;
            Rating = rating;
            Coins = new List<Coin>();
        }
    }
}
