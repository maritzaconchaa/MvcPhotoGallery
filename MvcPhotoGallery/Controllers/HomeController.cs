using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MvcPhotoGallery.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MvcPhotoGallery.Controllers
{
    public class HomeController : AsyncController
    {
        [AsyncTimeout(5000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            /*Version without asyncController*/ 
            //var response = client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme)).Result;
            //var value = response.Content.ReadAsStringAsync().Result;
            //var result = JsonConvert.DeserializeObject<List<Photo>>(value);
            
            /*version without cancellation token*/
            //var response = await client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme));

            var response = await client.GetAsync(Url.Action("gallery", "photo", null, Request.Url.Scheme), cancellationToken);
            var value = await response.Content.ReadAsStringAsync();
            var result = await JsonConvert.DeserializeObjectAsync<List<Photo>>(value);
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
