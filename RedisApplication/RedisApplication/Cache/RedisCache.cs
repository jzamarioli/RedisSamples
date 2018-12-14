using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace RedisApplication.Cache
{
    public class RedisCache : ICacheService, IDisposable 
    {
        private IDatabase _db;

        // CONNECTION
        public RedisCache()
        {
            string ConnectionString = "localhost:6379";
            //string ConnectionString = "localhost:6379, password=pwd";
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(ConnectionString);
            _db = redisConnection.GetDatabase();
        }

        // **************************************************************************************
        // STRINGS 
        // **************************************************************************************
        public bool StringSet(string key, string value)
        {
            return _db.StringSet(key, value);    
        }

        public string StringGet(string key)
        {
            return _db.StringGet(key);
        }



        // **************************************************************************************
        // HASHES 
        // **************************************************************************************
        public bool HashSet(string key, string field, string value)
        {
             return _db.HashSet(key, field, value);
        }

        public void HashDeleteField(string key, string field)
        {
             _db.HashDelete(key, field);
        }

        public long HashLength(string key)
        {
            return  _db.HashLength(key);
        }

        public string HashGet(string key, string field)
        {
            return  _db.HashGet(key, field);
        }

        public HashEntry[] HashGetAll(string key)
        {
            return  _db.HashGetAll(key);
        }

        public RedisValue[] HashFields(string key)
        {
            return _db.HashKeys(key);
        }



        // **************************************************************************************
        // LISTS 
        // **************************************************************************************
        public long SetListItem(string key, string value)
        {
            return _db.ListRightPush(key, value);
        }

        public void UpdateListItem(string key, byte index, string value)
        {
             _db.ListSetByIndex(key, index, value);            
        }

        public long RemoveListItem(string key, string value)
        {
            return _db.ListRemove(key, value);
        }

        public long ListLength(string key)
        {
            return _db.ListLength(key);
        }

        public string GetListItem(string key, byte index)
        {
            if (KeyExists(key))
            {
                return _db.ListGetByIndex(key, index).ToString();
            }
            else
            {
                return null;
            }
        }

        public string[] GetAllListItems(string key)
        {
            return ( _db.ListRange(key, 0, -1)).ToStringArray();
        }




        // **************************************************************************************
        // SETS 
        // **************************************************************************************
        public bool SetAdd(string key, string value)
        {
             return _db.SetAdd(key, value);
        }

        public IEnumerable<RedisValue> SetScan (string key, string pattern)
        {
            return _db.SetScan(key, pattern);
        }

        public bool SetRemove(string key, string value)
        {
            return _db.SetRemove(key, value);
        }

        public long SetLength(string key)
        {
            return _db.SetLength(key);
        }

        public RedisValue[] SetGetMembers(string key)
        {
            return  _db.SetMembers(key);
        }




        // **************************************************************************************
        // GENERAL ONES 
        // **************************************************************************************
        public bool KeyExists(string key)
        {
            return  _db.KeyExists(key);
        }

        public void KeyDelete(string key)
        {
             _db.KeyDelete(key);
        }



        public void Dispose()
        {
            _db = null;
        }

       
    }
}
