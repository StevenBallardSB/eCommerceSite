using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /// <summary>
    /// Helper class to provide Session management
    /// </summary>
    public static class SessionHelper
    {
        private const string MemberIdKey = "MemberId";
        private const string UserNameKey = "Username";

        /// <summary>
        ///  Creates a session for the user
        /// </summary>
        /// <param name="context"></param>
        /// <param name="memberId"></param>
        /// <param name="username"></param>
        public static void LogUserIn(IHttpContextAccessor context, int memberId, string username)
        {
            context.HttpContext.Session.SetInt32(MemberIdKey, memberId);
            context.HttpContext.Session.SetString(UserNameKey, username);
        }

        public static bool IsUserLoggedIn(IHttpContextAccessor context)
        {
            if (context.HttpContext.Session.GetInt32(MemberIdKey).HasValue)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///  Destroys the current users session
        /// </summary>
        /// <param name="context"></param>
        public static void LogUserOut(IHttpContextAccessor context)
        {
            context.HttpContext.Session.Clear();
        }

        /// <summary>
        ///  Gets the username of the current user if they are logged in.
        ///  Null is returned if the user is not logged in
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUsername(IHttpContextAccessor context)
        {
            return context.HttpContext.Session.GetString(UserNameKey);
        }

        /// <summary>
        ///  Returns the Memberid of the current user if they are logged in.
        ///  Null is returned if the user is not logged in
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static int? GetMemberId(IHttpContextAccessor context)
        {
            return context.HttpContext.Session.GetInt32(MemberIdKey);
        }
    }
}
