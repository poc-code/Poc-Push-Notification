using poc_push_notification.domain.Model;
using System.Collections.Generic;

namespace poc_push_notification.service.Interface
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
