using StackExchange.Redis;

namespace MyServer.Services
{
    public class RedisServiceImpl: IRedisService
    {
        private IConnectionMultiplexer _redisCon;
        public IDatabase _cache { set; get; }

        public RedisServiceImpl(IConnectionMultiplexer redisCon)
        {
            _redisCon = redisCon;
            _cache = redisCon.GetDatabase();
        }

        public string GetUrl(string shortURL)
        {
            string LongURL = _cache.StringGet(shortURL);
            if (LongURL == null)
                return String.Empty;
            return LongURL;
        }

        public void SaveUrl(string ShortURL, string LongURL)
        {
            if (LongURL != null)
            {
                this._cache.StringSet(ShortURL, LongURL);
            }
        }
    }
}
