using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleRecaptcha.Models
{
    public class ReCaptchaRespo
    {
        public bool Success { get; set; }
        public DateTime Challenge_ts { get; set; }
        public string Hostname { get; set; }
        public long Score { get; set; }
    }
}
