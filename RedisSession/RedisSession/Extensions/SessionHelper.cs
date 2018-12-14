using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace RedisSession.Extensions
{
    public static class SessionHelper
    {
        public static void Set<T>(ISession session, string key, T value)
        {
            if (value.GetType().Namespace.StartsWith("System"))
                session.SetString(key, value.ToString());
            else
                session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            if (value == null)
                return (T) Convert.ChangeType(value, typeof(T));  
            
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>(value); 
            }
            
        }
    }
}