using ContactList.Exceptions;

namespace ContactList.MIddlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync (HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (BusinessException e)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Something went wrong. {e.Message}");
            }
        }
    }
}
