using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using poc_push_notification.api.Controllers;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using poc_push_notification.tests.DataMock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace poc_push_notification.tests.ControllersTest
{
    public class UserControllerTest
    {
        private Mock<IUserService> _serviceMock;

        public UserControllerTest()
        {
            _serviceMock = new Mock<IUserService>();
        }

        [Fact]
        public void GetAll_SucessTest()
        {
            _serviceMock.Setup(x => x.GetAll()).Returns(UserMock.Faker.Generate(5));

            var userController = new UserController(_serviceMock.Object);
            var userService = userController.GetAll();

            var actionResult = Assert.IsType<OkObjectResult>(userService);
            var actionValue = Assert.IsAssignableFrom<IEnumerable<User>>(actionResult.Value);

            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [Fact]
        public void Authenticate_SucessTest()
        {
            var user = UserMock.Faker.Generate(1);
            var authenticateRespons = user.Select(x => new AuthenticateResponse(user.FirstOrDefault(),"") { 
                Id = x.Id,
                FullName = x.FullName,
                Username = x.Username,
                Token = ""
            }).FirstOrDefault();

            _serviceMock.Setup(x => x.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(authenticateRespons);

            var userController = new UserController(_serviceMock.Object);
            var userService = userController.Authenticate(new AuthenticateRequest { 
                Username = "Ze",
                Password = "Senha"
            });

            var actionResult = Assert.IsType<OkObjectResult>(userService);
            var actionValue = Assert.IsAssignableFrom<AuthenticateResponse>(actionResult.Value);

            Assert.NotNull(actionResult);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }
    }
}
