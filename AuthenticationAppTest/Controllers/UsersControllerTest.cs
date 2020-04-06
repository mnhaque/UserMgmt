namespace AuthenticationAppTest
{
    using AuthenticationApplication.Controllers;
    using AuthenticationApplication.DAL;
    using AuthenticationApplication.Framework;
    using AuthenticationApplication.Models;
    using Entities = AuthenticationApplication.Entities;
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;

    [TestClass]
    public class UsersControllerTest
    {
        private Mock<IUserService> userService;
        private Mock<IMapper> mapper;
        private UsersController controller;
        private Fixture fixture;
        private Entities.User userEntity;
        private User user;
        private string userNme = "userName";
        private string pwd = "password";

        [TestInitialize]
        public void Init()
        {
            this.userService = new Mock<IUserService>();
            this.mapper = new Mock<IMapper>();
            fixture = new Fixture();
            userEntity = fixture.Customize(new AutoMoqCustomization()).Create<Entities.User>();
            user = fixture.Customize(new AutoMoqCustomization()).Create<User>();
            controller = new UsersController(userService.Object, mapper.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            this.userService.VerifyAll();
            this.mapper.VerifyAll();
        }

        [TestMethod]
        public void Register_PositiveCase_Test()
        {
            var data = fixture.Customize(new AutoMoqCustomization()).Create<User>();
            userService.Setup(_ => _.Register(It.IsAny<User>())).ReturnsAsync(true);
            var result = controller.Register(data);
            Assert.AreEqual(result.Result, true);
        }

        [TestMethod]
        public void Register_Duplicate_Email_Throws_Exception()
        {
            userService.Setup(_ => _.Register(It.IsAny<User>())).Throws(new DuplicatePrimaryKeyException());
            var result = controller.Register(user);
            Assert.AreEqual(result.Status, TaskStatus.Faulted);
            Assert.AreEqual(result.Exception.InnerException.Message, "Email id already exists");
        }

        [TestMethod]
        public void Login_Positive_Case()
        {
            userService.Setup(_ => _.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(userEntity);
            mapper.Setup(_ => _.Map<User>(It.IsAny<Entities.User>())).Returns(new User {Email = userEntity.Email });
            var result = controller.Login(userNme, pwd);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Email, userEntity.Email);
        }

        [TestMethod]
        public void Login_Invalid_Credentials()
        {
            var resut = controller.Login(userNme, pwd);
            Assert.IsNull(resut);
        }

        [TestMethod, ExpectedException(typeof(System.Exception))]
        public void Login_Throws_Exception()
        {
            userService.Setup(_ => _.Login(It.IsAny<string>(), It.IsAny<string>())).Throws(new System.Exception());
            var result = controller.Login(userNme, pwd);
        }
    }
}
