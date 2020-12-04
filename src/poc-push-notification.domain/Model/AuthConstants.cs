namespace poc_push_notification.domain.Model
{
    public static class AuthConstants
    {
        public static class ClaimTypes
        {
            public const string Nome = "name";
            public const string Email = "emailaddress";
            public const string Cpf = "documento";
            public const string ApiAccess = "enterprise";
        }

        public static class Policies
        {
            public const string IsAdmin = "IsAdmin";
            public const string IsManager = "IsManager";
            public const string IsGuest = "IsGuest";
            public const string All = "All";
        }

        public static class Role
        {
            public const string Guest = "guest";
            public const string Admin = "admin";
            public const string Manager = "manager";
        }
    }
}
