using System.Collections.Generic;

namespace ApiWithRole2.Services
{
    public class SessionManager
    {
        private static Dictionary<string, string> _sessions = new Dictionary<string, string>();

        public static void SaveToken(string username, string token)
        {
            _sessions[username] = token;
        }

        public static string GetToken(string username)
        {
            _sessions.TryGetValue(username, out var token);
            return token;
        }
    }
}
