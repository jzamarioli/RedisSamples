using RedisApplication.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisApplication
{
    public class RedisList
    {
        private const string _key = "list-gender";

        public RedisList()
        {
        }

        public void CallList()
        {
            using (RedisCache cache = new RedisCache())
            {
                Console.Clear();
                Console.WriteLine($"Press a key to insert an item to the list: {_key}");
                Console.ReadKey();
                long l;
                l = cache.SetListItem(_key, "Male");
                l = cache.SetListItem(_key, "Female");
                Console.WriteLine($"{cache.ListLength(_key)} Items inserted to list: {_key}");
                Console.WriteLine();

                Console.WriteLine($"Press a key to read all items in the list");
                Console.ReadKey();
                Console.WriteLine(string.Concat("List length: ", cache.ListLength(_key)));
                foreach (var item in cache.GetAllListItems(_key))
                {
                    Console.WriteLine(string.Concat("value: ", item));

                }
                Console.WriteLine();

                Console.WriteLine($"Press a key to read the item at the 1st position");
                Console.ReadKey();
                Console.WriteLine(string.Concat("value: ", cache.GetListItem(_key, 0)));
                Console.WriteLine();

                Console.WriteLine($"Press a key to update the item at the 1st position");
                Console.ReadKey();
                cache.UpdateListItem(_key, 0, "Alpha Male");
                Console.WriteLine();

                Console.WriteLine(string.Concat("List length: ", cache.ListLength(_key)));
                foreach (var item in cache.GetAllListItems(_key))
                {
                    Console.WriteLine(string.Concat("value: ", item));

                }
                Console.WriteLine();

                Console.WriteLine("Press a key to delete the value 'Female'");
                Console.ReadKey();
                cache.RemoveListItem(_key, "Female");
                Console.WriteLine();

                Console.WriteLine(string.Concat("List length: ", cache.ListLength(_key)));
                foreach (var item in cache.GetAllListItems(_key))
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
