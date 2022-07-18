namespace MyServer.Services
{
    public interface IRedisService
    {
        void SaveUrl(string shortURL, string longURL);
        string GetUrl(string shortURL);
    }
}
