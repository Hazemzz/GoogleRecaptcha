using GoogleRecaptcha.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace GoogleRecaptcha.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View((new ReCaptchaData()));
        }

        [HttpPost]
        public HttpStatusCode ReCaptcha(string response)
        {
            if (!ReCaptchaPassed(response))
            {
                ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                return HttpStatusCode.BadRequest;
            }
            return HttpStatusCode.OK;
        }

        private bool ReCaptchaPassed(string response)
        {
            HttpClient httpClient = new HttpClient();
            ReCaptchaData recaptcha = new ReCaptchaData();

            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={recaptcha.SecretV2}&response={response}").Result;

            if (res.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }
            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);

            if (JSONdata.success != "true" || JSONdata.score <= 0.5m)
            {
                return false;
            }

            return true;
        }
    }
}
