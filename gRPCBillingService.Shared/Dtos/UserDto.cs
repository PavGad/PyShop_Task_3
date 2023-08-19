using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCBillingService.Shared.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public long Amount { get; set; }
        public UserDto()
        {

        }
        public UserDto(string name, int amount)
        {
            Name = name;
            Amount = Amount;
        }
    }
}
