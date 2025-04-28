using Microsoft.AspNetCore.Diagnostics;
using MK1_8Semestr.Exceptions;

namespace MK1_8Semestr.ExceptionHandlers
{
    public class TitelValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is TitelValidationException ex)
            {
                httpContext.Response.StatusCode = 400;

                await httpContext.Response
                    .WriteAsJsonAsync(new
                    {
                        target = ex.Field,
                        description = ex.Description
                    },
                    cancellationToken);

                return true;
            }

            return false;
        }
    }
}
