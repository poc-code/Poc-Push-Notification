using Moq;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using poc_push_notification.tests.DataMock;
using System.Collections.Generic;
using Xunit;

namespace poc_push_notification.tests.ServicesTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserService> _service;

        public UserServiceTest()
        {
            _service = new Mock<IUserService>();
        }

        [Fact]
        public void GetAll_SuccessTest()
        {
            var retorno = UserMock.Faker.Generate(3);
            _service.Setup(x => x.GetAll()).Returns(retorno);

            var response = _service.Object.GetAll();

            Assert.NotNull(response);
            Assert.IsAssignableFrom<IEnumerable<User>>(response);
        }

        [Fact]
        public void GetById_SuccessTest()
        {
            var retorno = UserMock.Faker.Generate();
            _service.Setup(x => x.GetById(It.IsAny<int>())).Returns(retorno);

            var response = _service.Object.GetById(1);

            Assert.NotNull(response);
            Assert.IsAssignableFrom<User>(response);
        }
        
        [Fact]
        public void generateJwtToken_SuccessTest()
        {
            var user = UserMock.Faker.Generate();
            var retorno = new AuthenticateResponse(user, "");

            _service.Setup(x => x.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(retorno);

            var response = _service.Object.Authenticate(new AuthenticateRequest());

            Assert.NotNull(response);
            Assert.IsAssignableFrom<AuthenticateResponse>(response);
        }
    }
}
