using System.Security.Claims;
using Web.Extensions;
using Web.Models;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketViewModelService(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext!;
        public string? UserId => _createAnonId ?? HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public string? AnonId => HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];

        public string BuyerId => UserId ?? AnonId ?? CreateAnonymousId();
        private string _createAnonId;

        private string CreateAnonymousId()
        {
            _createAnonId=Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, _createAnonId, new CookieOptions()
            {
                Expires=DateTime.Now.AddMonths(2),
                IsEssential=true
            });

            return _createAnonId;
        }

        public async Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            var basket=await _basketService.AddItemToBasketAsync(BuyerId, productId, quantity);
            return basket.ToBasketViewModel();

        }

        public async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            var basket = await _basketService.GetOrCreateBasketAsync(BuyerId);
            return basket.ToBasketViewModel();
        }

        public async Task EmtyBasketAsync()
        {
            await _basketService.EmptyBasketAsync(BuyerId);
        }

        public async Task DeleteBasketItemAsync(int productId)
        {
            await _basketService.DeleteBasketItemAsync(BuyerId,productId);
        }

        public async Task UpdateBasketAsync(Dictionary<int, int> quantities)
        {
            await _basketService.SetQuantities(BuyerId, quantities);
        }

        public async Task TransferBasketIfNecessary()
        {
            if(UserId != null && AnonId != null)
            {
                await _basketService.TransferBasketAsync(AnonId, UserId);
            }
        }
    }
}
