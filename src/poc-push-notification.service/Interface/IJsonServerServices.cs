using poc_push_notification.domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poc_push_notification.service.Interface
{
    public interface IJsonServerServices
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByCredential(User user);
        Task<User> NewUser(User user);
        Task<User> EditUser(User user);
    }
}
