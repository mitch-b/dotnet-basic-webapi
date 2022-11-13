using BasicWebApi.Models;

namespace BasicWebApi.Filters
{
    public class ExceptionFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly bool _hideExceptionDetailsToClients;

        public ExceptionFilter(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<ExceptionFilter>();
            _hideExceptionDetailsToClients = configuration.GetValue<bool>("HideExceptionDetailsToClients");
        }

        public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            object? result = null;
            try
            {
                result = await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                if (_hideExceptionDetailsToClients)
                {
                    return new ErrorResult<string>
                    {
                        Messages = new[] { "An error occurred." }
                    };
                }
                throw;
            }
            return result;
        }
    }
}

