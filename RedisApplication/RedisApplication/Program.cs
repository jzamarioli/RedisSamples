using System;

namespace RedisApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            while (option.ToUpper() != "Q")
            {
                Console.Clear();
                Console.WriteLine("Press:\n(1) Strings\n(2) Hashs\n(3) Lists\n(4) Sets\n(Q) Quit");
                option = Console.ReadKey().KeyChar.ToString();
                switch (option)
                {
                    case "1":
                        RedisString();
                        break;
                    case "2":
                        RedisHash();
                        break;
                    case "3":
                        RedisList();
                        break;
                    case "4":
                        RedisSet();
                        break;
                }
            }
        }

        private static void RedisSet()
        {
            RedisSet rs = new RedisSet();
            rs.CallSet();
            rs = null;
        }

        private static void RedisList()
        {
            RedisList rl = new RedisList();
            rl.CallList();
            rl = null;
        }

        private static void RedisHash()
        {
            RedisHash rh = new RedisHash();
            rh.CallHash();
            rh = null;
        }

        private static void RedisString()
        {
            RedisString rs = new RedisString();
            rs.CallString();
            rs = null;
        }
    }
}
