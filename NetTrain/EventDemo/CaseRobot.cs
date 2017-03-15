using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class CaseRobot
    {
        public event Action eventAutoRunCase;

        public void AutoRunCase()
        {
            eventAutoRunCase();

            Console.WriteLine("Auto run finished.");
        }

    }

    public class GetCode
    {
        public Action GetLatest = () =>
        {
            Console.WriteLine("This is test get latestCode.");
        };
    }

    public class GetDatabase
    {
        public Action InitDB = () =>
        {
            Console.WriteLine("This is test get database.");
        };
    }

    public class StartIIS
    {
        public Action startiis = () =>
        {
            Console.WriteLine("This is start iis.");
        };
    }

    public class RunTestCase
    {
        public Action runCase = () =>
        {
            GetFailedCase();
            Console.WriteLine("This is run cases.");
        };

        public static void GetFailedCase()
        {
            Console.WriteLine("This is GetFailed case.");
            Console.WriteLine("");
        }
    }

    public class SendEmail
    {
        public Action sendEmail = () =>
        {
            Console.WriteLine("This is Send Emails.");
        };
    }
}
