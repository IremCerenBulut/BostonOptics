namespace Web.Middlewares
{
    public class TransferBasketMiddleware
    {
        private readonly RequestDelegate _next;

        public TransferBasketMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task InvokeAsync(HttpContext context, IBasketViewModelService basketViewModelService)
        {
            //basketviewmodelservice a sepetleri -eğer gerkiyorsa- taşı
            //metodu yaz ve burada çağır
            await basketViewModelService.TransferBasketIfNecessary();
            await _next(context);
        } 
    }
}
