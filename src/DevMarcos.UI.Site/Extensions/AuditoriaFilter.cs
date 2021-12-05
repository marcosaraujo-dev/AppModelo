//using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevMarcos.UI.Site.Extensions
{
    public class AuditoriaFilter : IActionFilter
    {
        //   private readonly ILogger _logger;
        //
        //   public AuditoriaFilter(ILogger logger)
        //   {
        //       _logger = logger;
        //   }

        //   public void OnActionExecuting(ActionExecutingContext context){}
        //
        //   public void OnActionExecuted(ActionExecutedContext context)
        //   {
        //       if (context.HttpContext.User.Identity.IsAuthenticated)
        //       {
        //           var message = context.HttpContext.User.Identity.Name + " Acessou: " +
        //                         context.HttpContext.Request.GetDisplayUrl();
        //
        //           _logger.Info(message);
        //       }
        //   }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
