using Billing;
using Grpc.Core;
using gRPCBillingService.Domain.Interfaces;
using gRPCBillingService.Shared.Dtos;

namespace gRPCBillingService.Api.Services
{
    public class BillingService : Billing.Billing.BillingBase
    {

        private readonly ILogger<BillingService> _logger;
        private readonly IUserService _userService;
        private readonly ICoinService _coinService;
        public BillingService(ILogger<BillingService> logger, IUserService userService, ICoinService coinService)
        {
            _logger = logger;
            _userService = userService;
            _coinService = coinService;
        }

        public override async Task ListUsers(None request, IServerStreamWriter<UserProfile> responseStream, ServerCallContext context)
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                users = new List<UserDto>();
            }

            foreach (var item in users)
            {
                await responseStream.WriteAsync(new UserProfile() { Name = item.Name, Amount = item.Amount });
            }

        }

        public override async Task<Response> CoinsEmission(EmissionAmount request, ServerCallContext context)
        {
            try
            {
                _coinService.EmitCoins(request.Amount);
            }
            catch (ArgumentException)
            {
                return new Response() { Status = Response.Types.Status.Failed };
            }
            return new Response() { Status = Response.Types.Status.Ok };
        }

        public override async Task<Response> MoveCoins(MoveCoinsTransaction request, ServerCallContext context)
        {

            try
            {
                _coinService.MoveCoins(request.Amount, request.SrcUser, request.DstUser);
            }
            catch (Exception ex)
            {
                return new Response() { Status = Response.Types.Status.Failed, Comment=ex.Message };
            }
            return new Response() { Status = Response.Types.Status.Ok };
        }

        public override async Task<Coin> LongestHistoryCoin(None request, ServerCallContext context)
        {
            var coinithLongestHistory = _coinService.GetCoinWithLongestHistory();
            return new Coin() { Id = coinithLongestHistory.Id, History = coinithLongestHistory.History };
        }

    }
}
