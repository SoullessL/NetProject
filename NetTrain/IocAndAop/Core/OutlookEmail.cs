using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocAndAop.Core
{
    public class OutlookEmail : iSendEmail
    {
        public string SendEmail()
        {
            string str = "This is outlook send email function.";
            Console.WriteLine(str);
            return str;
        }
    }
}