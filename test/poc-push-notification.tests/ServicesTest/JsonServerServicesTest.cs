using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Moq;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using poc_push_notification.service.Services;
using poc_push_notification.tests.DataMock;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace poc_push_notification.tests.ServicesTest
{
    public class JsonServerServicesTest
    {
        private readonly Mock<IMemoryCache> _memoryCacheMock;
        private readonly Mock<IHttpClientFactory> _httpClientMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IJsonServerServices> _serviceMock;

        public JsonServerServicesTest()
        {
            _memoryCacheMock = new Mock<IMemoryCache>();
            _httpClientMock = new Mock<IHttpClientFactory>();
            _configurationMock = new Mock<IConfiguration>();
            _serviceMock = new Mock<IJsonServerServices>();
        }

        [Fact]
        public void GetAll_SucessTest()
        {
            var users = UserMock.Faker.Generate(3);
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(users);

            var service = new JsonServerServices(_memoryCacheMock.Object, _httpClientMock.Object, _configurationMock.Object);
            var resultado = service.GetAll();

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Task<IEnumerable<User>>>(resultado);
        }

        [Fact]
        public void GetCredential_SucessTest()
        {
            var user = UserMock.Faker.Generate();
            _serviceMock.Setup(x => x.GetByCredential(It.IsAny<User>())).ReturnsAsync(user);

            var service = new JsonServerServices(_memoryCacheMock.Object, _httpClientMock.Object, _configurationMock.Object);
            var resultado = service.GetByCredential(new User());

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Task<User>>(resultado);
        }

        [Fact]
        public void Insert_SucessTest()
        {
            var user = UserMock.Faker.Generate();
            _serviceMock.Setup(x => x.NewUser(It.IsAny<User>())).ReturnsAsync(user);

            var service = new JsonServerServices(_memoryCacheMock.Object, _httpClientMock.Object, _configurationMock.Object);
            var resultado = service.NewUser(user);

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Task<User>>(resultado);
        }

        [Fact]
        public void Edit_SucessTest()
        {
            var user = UserMock.Faker.Generate();
            _serviceMock.Setup(x => x.EditUser(It.IsAny<User>())).ReturnsAsync(user);

            var service = new JsonServerServices(_memoryCacheMock.Object, _httpClientMock.Object, _configurationMock.Object);
            var resultado = service.EditUser(user);

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Task<User>>(resultado);
        }

        [Fact]
        public void GetById_SucessTest()
        {
            var user = UserMock.Faker.Generate();
            _serviceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(user);

            var service = new JsonServerServices(_memoryCacheMock.Object, _httpClientMock.Object, _configurationMock.Object);
            var resultado = service.GetById(1);

            Assert.NotNull(resultado);
            Assert.IsAssignableFrom<Task<User>>(resultado);
        }

    }
}
