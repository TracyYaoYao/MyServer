namespace TinyURLService.Services
{
    public interface ITinyURLService
    {
        string EncodeURL(string url);

        string DecodeURL(string url);
    }
}
