using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IocAndAop.Core
{
    public class QqEmail : iSendEmail
    {
        public string SendEmail()
        {
            string str = "This is qq send email function.";
            Console.WriteLine(str);
            return str;
        }
    }
}