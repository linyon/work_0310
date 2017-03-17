using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Runtime.Caching;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            /* string Target_Uri = "http://opendata.epa.gov.tw/ws/Data/ATM00323/?$skip=0&$top=1000&format=json";

             HttpClient client = new HttpClient();
             client.MaxResponseContentBufferSize = Int32.MaxValue;
             var response = await client.GetStringAsync(Target_Uri);
             var collection = JsonConvert.DeserializeObject<IEnumerable<info_json>>(response);
             return View(collection);*/
            var Source = await this.GetData();
            ViewData.Model = Source;
            return View();
        }
        private async Task<IEnumerable<info_json>> GetData()
        {
            string cache_name = "air_";
            ObjectCache cache = MemoryCache.Default;
            CacheItem cacheContents = cache.GetCacheItem(cache_name);

            if (cacheContents == null)
            {
                return await RetriveData(cache_name);
            }
            else
            {
                return cacheContents.Value as IEnumerable<info_json>;
            }
        }
        private async Task<IEnumerable<info_json>> RetriveData(string cache_name)
        {
            string targetURI = "http://opendata.epa.gov.tw/ws/Data/ATM00323/?$skip=0&$top=1000&format=json";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var response = await client.GetStringAsync(targetURI);

            var collection = JsonConvert.DeserializeObject<IEnumerable<info_json>>(response);

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(30);

            ObjectCache cacheItem = MemoryCache.Default;
            cacheItem.Add(cache_name, collection, policy);

            return collection;
        }
    }
}