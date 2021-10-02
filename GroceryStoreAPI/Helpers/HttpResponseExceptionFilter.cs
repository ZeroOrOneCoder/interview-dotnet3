using Microsoft.AspNetCore.Mvc.Filters;

namespace GroceryStoreAPI.Helpers
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //if(context.Exception is HttpResponseException exception)
            //{

            //}
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
