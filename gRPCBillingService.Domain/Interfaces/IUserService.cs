using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Shared.Dtos;

namespace gRPCBillingService.Domain.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
    }
}
