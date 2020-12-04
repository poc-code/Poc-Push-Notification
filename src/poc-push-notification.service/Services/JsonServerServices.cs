using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace poc_push_notification.service.Services
{
    public class JsonServerServices : IJsonServerServices
    {
        private readonly IMemoryCache _memoryCache;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public JsonServerServices(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _httpClient = httpClientFactory.CreateClient("jsonfakeserver");
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                if (!_memoryCache.TryGetValue("UsersCache", out IEnumerable<User> users))
                {
                    var response = await _httpClient.GetAsync($"/users");
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        users = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<User>>(stringResponse);

                        var cacheOptions = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));

                        _memoryCache.Set("UsersCache", users, cacheOptions);
                    }
                }

                return users;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                 var user = new User();
                    var response = await _httpClient.GetAsync($"/users/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var stringResponse = await response.Content.ReadAsStringAsync();
                        user = System.Text.Json.JsonSerializer.Deserialize<User>(stringResponse);

                        var cacheOptions = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(15));
                    }

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> NewUser(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/users/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(stringResponse);
                }

                return user;

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<User> EditUser(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/users/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(stringResponse);
                }

                return user;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<User> GetByCredential(User credential)
        {
            try
            {
                IEnumerable<User> users = new List<User>();
                var response = await _httpClient.GetAsync($"/users?username=test&password=test", HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringResponse);
                }

                return users.FirstOrDefault();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
