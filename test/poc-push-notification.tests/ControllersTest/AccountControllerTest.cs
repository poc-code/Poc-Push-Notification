using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using poc_push_notification.api.Controllers;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using poc_push_notification.tests.DataMock;
using Xunit;

namespace poc_push_notification.tests.ControllersTest
{
    public class AccountControllerTest
    {
        private readonly Mock<ITokenService> _tokenService;

        public AccountControllerTest()
        {
            _tokenService = new Mock<ITokenService>();
            _tokenService.Setup(x => x.Generate(It.IsAny<User>())).Returns(new AuthResponse { 
                access_token = "",
                expires_in = 3600,
                token_type = "Bearer"
            });
        }

        [Fact]
        public void Generate_Success()
        {
            var user = UserMock.Faker.Generate();
            var accountController = new AccountController(_tokenService.Object);
            var action = accountController.Post(user);

            var actionResult = Assert.IsType<OkObjectResult>(action);
            var actionValue = Assert.IsAssignableFrom<AuthResponse>(actionResult.Value);

            Assert.NotNull(actionValue);
            Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
        }
    }
}
