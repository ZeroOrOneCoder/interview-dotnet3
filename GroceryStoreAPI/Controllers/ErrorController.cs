using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
