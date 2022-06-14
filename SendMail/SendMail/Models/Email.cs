using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendMail.Models
{
    public class Email
    {
        public string receiver { get; set; }
        public string subject { get; set; }
        public string message { get; set; }

    }
}