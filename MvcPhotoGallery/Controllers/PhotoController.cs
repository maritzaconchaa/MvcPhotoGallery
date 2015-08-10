using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPhotoGallery.Controllers
{
    public class PhotoController : Controller
    {
        //
        // GET: /PhotoController/

        public ActionResult Gallery()
        {
            //timeout option
            //add this in the web.config under system.web 
            //<customErrors mode="On"></customErrors>
            System.Threading.Thread.Sleep(1000);

            return this.File("~/App_Data/Photos.json", "application/json");
        }

    }
}
