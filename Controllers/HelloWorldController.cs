using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MyServer.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public string Index()
        {
            return "The first action";
        }

        // GET: /HelloWorld/Welcome
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTImes is {numTimes}");
        }
    }
}
