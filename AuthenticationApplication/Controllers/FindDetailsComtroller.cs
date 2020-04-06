namespace AuthenticationApplication.Controllers
{
    using AuthenticationApplication.Framework;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// the find details controller mvc controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ExceptionFilter]
    public class FindDetailsController : Controller
    {
        public FindDetailsController()
        {
        }
        /// <summary>
        /// The Index Action
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
