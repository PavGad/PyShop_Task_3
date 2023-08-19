using gRPCBillingService.Domain.Interfaces;
using gRPCBillingService.Persistence.Entities;
using gRPCBillingService.Persistence.Interfaces;
using gRPCBillingService.Shared.Dtos;

namespace gRPCBillingService.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repo)
        {
              this._userRepository = repo;
        }
        public IEnumerable<UserDto> GetUsers()
        {
            return _userRepository.GetUsers().Select(x => new UserDto { Name = x.Name, Amount = x.Amount }).ToList();
        }
    }
}
