using poc_push_notification.domain.Model;

namespace poc_push_notification.service.Interface
{
    public interface ITokenService
    {
        AuthResponse Generate(User user);

    }
}
