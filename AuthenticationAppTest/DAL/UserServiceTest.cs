namespace AuthenticationAppTest.DAL
{
    using System.Threading.Tasks;
    using AuthenticationApplication.DAL;
    using AuthenticationApplication.Entities;
    using AuthenticationApplication.Framework;
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Models = AuthenticationApplication.Models;

    [TestClass]
    public class UserServiceTest
    {
        private Fixture fixture;
        private DataContext dataContext;
        private Mock<IMapper> mapper;
        private UserService instance;
        private string userNme = "userName";
        private string pwd = "password";
        [TestInitialize]
        public void Init()
        {
            fixture = new Fixture();
            mapper = new Mock<IMapper>();
            var user = fixture.Customize(new AutoMoqCustomization()).Create<User>();
            user.Email = userNme;
            user.Password = pwd;
            var context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("User").Options);
            context.Users.AddRange(user);
            int changed = context.SaveChanges();
            dataContext = context;
            instance = new UserService(dataContext, mapper.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            dataContext.Users.RemoveRange(dataContext.Users);
            dataContext.SaveChanges();
            mapper.VerifyAll();
        }
        [TestMethod]
        public void Login_Success_Case()
        {
            var result = instance.Login(userNme, pwd);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Login_Failure_Case()
        {
            var result = instance.Login(userNme, "abc");
            Assert.IsNull(result);
        }
        [TestMethod]
        public void RegisterUser_Success_Case()
        {
            var user = fixture.Customize(new AutoMoqCustomization()).Create<Models.User>();
            mapper.Setup(_ => _.Map<User>(It.IsAny<Models.User>())).Returns(new User { Email = user.Email, Password = user.Password });
            var result = instance.Register(user);
            Assert.IsTrue(result.Result);
        }
        [TestMethod]
        public void Register_Throws_Already_Exists_Exception()
        {
            var user = fixture.Customize(new AutoMoqCustomization()).Create<Models.User>();
            user.Email = userNme;
            var result = instance.Register(user);
            Assert.AreEqual(result.Status, TaskStatus.Faulted);
            Assert.AreEqual(result.Exception.InnerException.Message, "Email id already exists");
        }
    }
}
