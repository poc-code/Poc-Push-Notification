using Newtonsoft.Json;

namespace poc_push_notification.domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        [JsonProperty("role")]
        public string Role { get;  set; }
    }
}
