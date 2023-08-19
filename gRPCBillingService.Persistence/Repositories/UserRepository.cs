using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Persistence.Interfaces;

namespace gRPCBillingService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>() {
            new User("boris", 5000),
            new User("maria", 1000),
            new User("oleg", 800)
        };
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }
    }
}
