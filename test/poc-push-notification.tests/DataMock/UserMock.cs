using Bogus;
using poc_push_notification.domain.Model;
using System.Collections.Generic;

namespace poc_push_notification.tests.DataMock
{
    public static class UserMock
    {
        public static Faker<User> Faker =>
            new Faker<User>()
            .CustomInstantiator(x => new User
            { 
                Id = x.IndexVariable++,
                FullName = x.Person.FullName,
                Email = x.Person.Email,
                Username = x.Person.UserName,
                Password = x.Random.Word(),
                Role = x.Random.ListItem(new List<string> { AuthConstants.Role.Guest, AuthConstants.Role.Manager, AuthConstants.Role.Admin })
            });
    }
}
