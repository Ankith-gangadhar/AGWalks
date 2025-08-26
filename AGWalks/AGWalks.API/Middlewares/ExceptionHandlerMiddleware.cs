using System.Net;

namespace AGWalks.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await next(httpcontext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                logger.LogError(ex, $"{errorId} : {ex.Message}");
                httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError ;
                httpcontext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong. We are looking in resolving this"
                };
                await httpcontext.Response.WriteAsJsonAsync(error);

            }
        }


    }
}
