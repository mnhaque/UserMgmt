namespace AuthenticationApplication.Controllers
{
    using System.Diagnostics;
    using AuthenticationApplication.Framework;
    using AuthenticationApplication.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// the home controller mvc controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ExceptionFilter]
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Welcomes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        [ExceptionFilter]
        public IActionResult Welcome(string name, string lastName)
        {
            return View(new User { FirstName=name, LastName=lastName});
        }
    }
}
