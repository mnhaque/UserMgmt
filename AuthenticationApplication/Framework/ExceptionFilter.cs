namespace AuthenticationApplication.Framework
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// the ExceptionFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute" />
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            HttpResponse response = context.HttpContext.Response;
            if (exception.GetType() == typeof(DuplicatePrimaryKeyException))
            {
                context.ExceptionHandled = true;
                response.StatusCode = 400;
                response.WriteAsync(exception.Message);
            }
        }
    }
}
