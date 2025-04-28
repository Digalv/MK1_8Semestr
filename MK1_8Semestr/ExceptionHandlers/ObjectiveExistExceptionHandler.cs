using Microsoft.AspNetCore.Diagnostics;
using MK1_8Semestr.Exceptions;

namespace MK1_8Semestr.ExceptionHandlers
{
    public class ObjectiveExistExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ObjectiveExistException ex)
            {
                httpContext.Response.StatusCode = 409;

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

