using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisApplication.Cache
{
    public interface ICacheService
    {
        bool StringSet(string key, string value);
        void KeyDelete(string key);
        string StringGet(string key);

        bool HashSet(string key, string field, string value);
        void HashDeleteField(string key, string field);
        long HashLength(string key);
        string HashGet(string key, string field);
        HashEntry[] HashGetAll(string key);
        RedisValue[] HashFields(string key);

        long SetListItem(string key, string value);
        void UpdateListItem(string key, byte index, string value);
        long RemoveListItem(string key, string value);
        long ListLength(string key);
        string GetListItem(string key, byte index);
        string[] GetAllListItems(string key);


        bool SetAdd(string key, string value);
        IEnumerable<RedisValue> SetScan(string key, string pattern);
        bool SetRemove(string key, string value);
        long SetLength(string key);
        RedisValue[] SetGetMembers(string key);


        bool KeyExists(string key);
        
    }
}
