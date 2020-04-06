namespace AuthenticationApplication.DAL
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AuthenticationApplication.Entities;
    using AuthenticationApplication.Framework;
    using AutoMapper;

    /// <summary>
    /// the user service class
    /// </summary>
    /// <seealso cref="AuthenticationApplication.DAL.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The data context
        /// </summary>
        private readonly DataContext dataContext;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>
        public UserService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public User Login(string userName, string password)
        {
            return dataContext.Users.FirstOrDefault(x => x.Email.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password));
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="DuplicatePrimaryKeyException"></exception>
        public async Task<bool> Register(Models.User user)
        {

            if (dataContext.Users.Any(x=>x.Email.Equals(user.Email)))
            {
                throw new DuplicatePrimaryKeyException();
            }
            dataContext.Users.Add(mapper.Map<User>(user));
            await dataContext.SaveChangesAsync();
            return true;
        }

    }
}
