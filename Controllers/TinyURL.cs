using Microsoft.AspNetCore.Mvc;
using TinyURLService.Services;

namespace TinyURLService.Controllers
{
    public class TinyURL : Controller
    {
        private ITinyURLService _tinyURLService;

        public TinyURL(ITinyURLService svc)
        {
            _tinyURLService = svc;
        }

        public string Encode(string url)
        {
            if(url == null)
            {
                return "url cannot be null";
            }
            return _tinyURLService.EncodeURL(url); 
        }

        public string Decode()
        {
            return "TinyURL Decode method.";
        }

        public string Index()
        {
            return "TinyURL Default Home Page.";
        }
    }
}
