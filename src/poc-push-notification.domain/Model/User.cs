using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace poc_push_notification.domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
