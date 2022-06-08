using GoogleRecaptcha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace GoogleRecaptcha.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View((new ReCaptchaData()));
        }

        [HttpPost]
        public JsonResult ReCaptcha(string response)
        {
            ReCaptchaData recaptcha = new ReCaptchaData();
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptcha.SecretV2 + "&response=" + response;
            recaptcha.Response = (new WebClient()).DownloadString(url);
            return Json(recaptcha);
        }
    }
}
