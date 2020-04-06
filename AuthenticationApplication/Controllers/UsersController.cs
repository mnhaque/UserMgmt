namespace AuthenticationApplication.Controllers
{
    using System.Threading.Tasks;
    using AuthenticationApplication.DAL;
    using AuthenticationApplication.Framework;
    using AuthenticationApplication.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// the user api controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Users")]
    [ExceptionFilter]
    public class UsersController : Controller
    {
        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService userService;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="mapper">The mapper.</param>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter]
        [Route("Register")]
        public async Task<bool> Register([FromBody]User user)
        {
            return await this.userService.Register(user);
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="pwd">The password.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]
        [ExceptionFilter]
        public User Login(string userName, string pwd)
        {
            User response = null;
            var user = this.userService.Login(userName, pwd);
            if (user != null)
            {
                return mapper.Map<User>(user);
            }
            return response;
        }
    }
}