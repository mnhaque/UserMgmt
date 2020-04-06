namespace AuthenticationApplication
{
    using AuthenticationApplication.Entities;
    using AutoMapper;
    /// <summary>
    /// custom automapper profiling
    /// </summary>
    /// <seealso cref="Profile" />
    public class AutoMapperProfileConfiguration : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfileConfiguration"/> class.
        /// </summary>
        public AutoMapperProfileConfiguration() : this("Profile")
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfileConfiguration"/> class.
        /// </summary>
        /// <param name="profileName">Name of the profile.</param>
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Models.User, User>();
        }
    }
}
