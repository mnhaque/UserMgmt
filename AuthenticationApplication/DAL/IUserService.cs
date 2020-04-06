namespace AuthenticationApplication.DAL
{
    using AuthenticationApplication.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// the IUserService interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> Register(User user);
        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Entities.User Login(string userName, string password);
    }
}