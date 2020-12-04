using Newtonsoft.Json.Converters;
using poc_push_notification.domain.Enum;
using System.Text.Json.Serialization;

namespace poc_push_notification.api.ViewModel.user
{
    public class AccountInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
