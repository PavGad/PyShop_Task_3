using gRPCBillingService.Persistence.Entities;

namespace gRPCBillingService.Persistence.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
