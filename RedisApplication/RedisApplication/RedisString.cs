using RedisApplication.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisApplication
{
    public class RedisString
    {
        private const string _key = "string1";

        public RedisString()
        {
        }

        public  void CallString()
        {
            using (RedisCache cache = new RedisCache())
            {
                Console.Clear();
                Console.WriteLine($"Press a key to insert the key: {_key}");
                Console.ReadKey();
                bool b =  cache.StringSet(_key, "blablabla");
                Console.WriteLine($"Key: {_key} inserted");
                Console.WriteLine();

                Console.WriteLine($"Press a key to read the key: {_key}");
                Console.ReadKey();
                Console.WriteLine(string.Concat("key ",_key, ": ", cache.StringGet(_key)));
                Console.WriteLine();

                Console.WriteLine($"Press a key to update the key {_key}");
                Console.ReadKey();
                b = cache.StringSet(_key, "nononono");

                Console.WriteLine(string.Concat("key ", _key, " updated: ", cache.StringGet(_key)));
                Console.WriteLine();

                Console.WriteLine("Press a key to delete the string");
                Console.ReadKey();
                cache.KeyDelete(_key);

                if (! cache.KeyExists(_key)) {
                    Console.WriteLine("Key deleted.");
                }

                Console.WriteLine("\nPress any key to exit");                
                Console.ReadKey();
            }
        }

    }
}
