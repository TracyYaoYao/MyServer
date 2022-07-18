using System.Security.Cryptography;
using System.Text;
using StackExchange.Redis;
using MyServer.Services;


namespace TinyURLService.Services
{
    public class TinyURLServiceImpl: ITinyURLService
    {
        private int INF = 0x3FFFFFFF;
        private int MASK = 0x00000030;
        private string ALPHA = "abcdefghigklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private IRedisService _redisService;
        protected readonly IDatabase db;
        public TinyURLServiceImpl(IRedisService redis)
        {
            _redisService = redis;
        }

        public string encode(string longURL)
        {
            return "TinyURL" + longURL.Substring(0, 3);
        }

        /*
        public string encode(string url)
        {
            // 1. Hash an input string and return the hash has a 32 character hexademical string.

            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(url));

            // Create a new Stringbuilder to collect the bytes and creat a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each bytes of the hash data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            //Return the hexadecimal string.
            //return sBuilder.ToString();

            // 2. Generate 4 strings
            String[] res = new String[4];

            for (int i = 0; i < 4; i++)
            {
                string byteValue = sBuilder.ToString().Substring(i * 8, (i + 1) * 8);
                int hexValue = Convert.ToInt32(byteValue);
                int tmpValue = INF & hexValue;
                string TinyURL = "";

                for (int j = 0; j < 6; j++)
                {
                    TinyURL = TinyURL + ALPHA[MASK & tmpValue];
                    tmpValue = tmpValue >> 5;
                }

                res.Append(TinyURL);
            }

            // 3. Return the first one. Rand() is better.
            return res[0];
        }
        */

        public string EncodeURL(string longURL)
        {
            string shortURL = encode(longURL);
            _redisService.SaveUrl(shortURL, longURL);
            return shortURL;
        }

        public string DecodeURL(string url)
        {
            return "decode";
        }
    }
}
