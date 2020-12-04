using Microsoft.Extensions.Configuration;
using Moq;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using poc_push_notification.service.Services;
using poc_push_notification.tests.DataMock;
using Xunit;

namespace poc_push_notification.tests.ServicesTest
{
    public class TokenServiceTest
    {
        private readonly Mock<ITokenService> _serviceMock;
        private readonly Mock<IJsonServerServices> _jsonServiceMock;
        private readonly Mock<IConfiguration> _confiMock;

        public TokenServiceTest()
        {
            _serviceMock = new Mock<ITokenService>();
            _jsonServiceMock = new Mock<IJsonServerServices>();
            _confiMock = new Mock<IConfiguration>();
        }

        [Fact]
        public void Generate_Success()
        {
            var user = UserMock.Faker.Generate();
            var retorno = new AuthResponse { 
                expires_in = 3600,
                access_token = "",
                token_type = "Bearer"
            };

            _jsonServiceMock.Setup(x => x.GetByCredential(It.IsAny<User>())).ReturnsAsync(user);
            _confiMock.Setup(x => x["AppSettings:Secret"]).Returns("236fa274-3bf3-43f8-b07c-3607a9bb3d2c");

            var service = new TokenService(_confiMock.Object, _jsonServiceMock.Object);
            var resultado = service.Generate(user);

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<AuthResponse>(resultado);
        }
    }
}
