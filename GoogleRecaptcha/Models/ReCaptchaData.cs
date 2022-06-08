using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleRecaptcha.Models
{
    public class ReCaptchaData
    {
        public string Response { get; set; }
        public string Secret { get; set; }
        public string SecretV2 = "6Lc3tU8gAAAAAAULsTguNDANr_plJSBPqB9SVKNw";
    }

}
