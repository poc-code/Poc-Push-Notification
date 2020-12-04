namespace poc_push_notification.domain.Model
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public double expires_in { get; set; }
        public string token_type { get; set; }
    }
}
