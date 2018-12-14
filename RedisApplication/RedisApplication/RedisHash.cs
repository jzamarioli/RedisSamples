using RedisApplication.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisApplication
{
    public class RedisHash
    {
        private const string _key = "hash1";

        public RedisHash()
        {
        }

        public  void CallHash()
        {
            using (RedisCache cache = new RedisCache())
            {
                Console.Clear();
                Console.WriteLine($"Press a key to insert the hash: {_key}");
                Console.ReadKey();
                bool insertOK;
                insertOK = cache.HashSet(_key, "Id", "1");
                insertOK = cache.HashSet(_key, "Name", "jersey");
                insertOK = cache.HashSet(_key, "Price", "40");
                insertOK = cache.HashSet(_key, "UpdatedOn", DateTime.Now.ToShortDateString());

                Console.WriteLine();
                Console.WriteLine(string.Concat("Hash length: ", cache.HashLength(_key)));                
                foreach (var field in cache.HashFields(_key))
                {
                    Console.WriteLine( field.ToString());
                }
                Console.WriteLine();

                Console.WriteLine("Press a key to read the field: 'price'");
                Console.ReadKey();
                Console.WriteLine( cache.HashGet(_key, "Price"));
                Console.WriteLine();

                Console.WriteLine("Press a key to update the field: 'price'");
                Console.ReadKey();
                insertOK = cache.HashSet(_key, "Price", "80");
                
                Console.WriteLine(string.Concat("Price changed to: ",  cache.HashGet(_key, "Price")));
                Console.WriteLine();

                Console.WriteLine("Press a key to delete the field: 'price'");
                Console.ReadKey();
                cache.HashDeleteField(_key, "Price");
                Console.WriteLine();

                Console.WriteLine(string.Concat("Hash length: ",  cache.HashLength(_key)));
                foreach (var field in cache.HashFields(_key))
                {
                    Console.WriteLine(field.ToString());
                }
                Console.WriteLine();

                Console.WriteLine("Press a key to delete the entire hash");
                Console.ReadKey();
                cache.KeyDelete(_key);

                if (! cache.KeyExists(_key))
                {
                    Console.WriteLine("Hash deleted.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
