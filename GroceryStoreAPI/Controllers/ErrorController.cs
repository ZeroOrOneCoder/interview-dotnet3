using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}
