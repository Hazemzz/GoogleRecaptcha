using GoogleRecaptcha.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleRecaptcha.Service
{
    public class reCaptchaService
    {
        public virtual async Task<ReCaptchaRespo> tokenVerify(string token)
        {
            ReCaptchaData data = new ReCaptchaData
            {
                Response = token,
                Secret = "6LeVUk8gAAAAAK-jpy6hyYv5PF4--7nV5CDvtPku"
            };

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={data.Secret}&response={data.Response}");
            var reCaptcharesponse = JsonConvert.DeserializeObject<ReCaptchaRespo>(response);
            return reCaptcharesponse;
        }
    }
}
