using poc_push_notification.api.ViewModel.user;
using poc_push_notification.domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace poc_push_notification.api.Helpers
{
    public static class AccessHelper
    {
        public static AccountInfo getTokenAttributes(IEnumerable<Claim> userClaims)
        {
            var user = new AccountInfo();
            if (userClaims?.Any() == true)
            {
                    user.Username = userClaims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value;
                    user.Email = userClaims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value;
                    user.FullName = userClaims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                    user.Role = userClaims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Role)).Value;
            }
            return user;
        }
    }
}
