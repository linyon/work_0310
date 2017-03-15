using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace WebApplication1.Controllers
{
    public class HotSpotController : Controller
    {
        // GET: HotSpot
        public async Task<ActionResult> Index() {
            string Target_Uri = "http://opendata.epa.gov.tw/ws/Data/ATM00323/?$skip=0&$top=1000&format=json";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var response = await client.GetStringAsync(Target_Uri);
            ViewBag.Result = response;
            return View();
        }
    }
}