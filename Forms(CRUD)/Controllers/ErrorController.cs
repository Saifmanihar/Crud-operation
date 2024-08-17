using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Forms_CRUD_.Controllers
{
    public class HomeController1 : Controller
    {


        [Route("/Error/{StatusCode}")]
        public IActionResult HandlerRequestId(int  StatusCode)
        {
            switch (StatusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry Reqested Page not Found";
                    break; 
            }
            return View("NotFound");
        }

        //Global error handling
        [Route("/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var ExceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewBag.ErrorMessage = ExceptionHandler.Error.Message;
            ViewBag.ErrorPath = ExceptionHandler.Path;
            ViewBag.StackTrace = ExceptionHandler.Error.StackTrace;
            return View();
        }
    }
}
