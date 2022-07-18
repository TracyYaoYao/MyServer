namespace TinyURLService.Models
{
    public class TinyURL
    {
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public int VistedCounts { get; set; }

        public TinyURL(string longURL, string shortURL, int vistedCounts = 0)
        {
            this.LongURL = longURL;
            this.ShortURL = shortURL;
            this.VistedCounts = vistedCounts;
        }
    }
}
