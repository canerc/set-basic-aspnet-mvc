﻿using System;
using System.Security.Principal;

namespace set_basic_aspnet_mvc.Helpers
{
    public static class IdentityHelper
    {
        public static long GetUserId(this IIdentity identity)
        {
            return identity.IsAuthenticated ? Convert.ToInt64(identity.Name.Split('|')[0]) : 0;
        }

        public static string GetUserFullName(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[1] : string.Empty;
        }

        public static string GetUserEmail(this IIdentity identity)
        {
            return identity.IsAuthenticated ? identity.Name.Split('|')[2] : string.Empty;
        }

        public static int GetUserRoleId(this IIdentity identity)
        {
            return identity.IsAuthenticated ? Convert.ToInt32(identity.Name.Split('|')[3]) : 0;
        }
    }
}