using RedisApplication.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisApplication
{
    public class RedisSet
    {
        private const string _key = "set1";

        public RedisSet()
        {
        }

        public void CallSet()
        {
            using (RedisCache cache = new RedisCache())
            {
                Console.Clear();
                Console.WriteLine($"Press a key to insert an item to the set: {_key}");
                Console.ReadKey();
                bool setOK;
                setOK = cache.SetAdd(_key, "Male");
                setOK = cache.SetAdd(_key, "Female");
                Console.WriteLine($"{cache.SetLength(_key)} Items inserted to set: {_key}");
                Console.WriteLine();

                Console.WriteLine($"Press a key to read all items in the set");
                Console.ReadKey();
                Console.WriteLine(string.Concat("Set length: ", cache.SetLength(_key)));
                foreach (var item in cache.SetGetMembers(_key))
                {
                    Console.WriteLine(string.Concat("value: ", item));

                }
                Console.WriteLine();

                Console.WriteLine($"Press a key to read the items containing 'Female'");
                Console.ReadKey();
                foreach (var item in cache.SetScan(_key, "*Female"))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                Console.WriteLine("Press a key to delete the value 'Male'");
                Console.ReadKey();
                cache.SetRemove(_key, "Male");
                Console.WriteLine();

                Console.WriteLine(string.Concat("Set length: ", cache.SetLength(_key)));
                foreach (var item in cache.SetGetMembers(_key))
                {
                    Console.WriteLine(string.Concat("value: ", item));

                }
                Console.WriteLine();


                Console.WriteLine($"Press a key to delete the key {_key}");
                Console.ReadKey();
                cache.KeyDelete(_key);
                if (!cache.KeyExists(_key))
                {
                    Console.WriteLine("Key deleted.");
                }

                Console.WriteLine("\nPress any key to exit");
                Console.ReadKey();
            }
        }

    }

    
}
