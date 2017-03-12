using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Heater heater = new Heater();
            ////heater.Boiler += heater.MakeAlert;
            ////heater.Boiler += heater.ShowMes;
            //heater.BoilWater();


            CaseRobot cr = new CaseRobot();
            cr.eventAutoRunCase += new GetCode().GetLatest;
            cr.eventAutoRunCase += new GetDatabase().InitDB;
            cr.eventAutoRunCase += new StartIIS().startiis;
            cr.eventAutoRunCase += new RunTestCase().runCase;
            cr.eventAutoRunCase += new SendEmail().sendEmail;
            cr.AutoRunCase();

            Console.ReadKey();
        }
    }

    public class Heater
    {
        public Action<int> MakeAlert = (i) =>
         {
             Console.WriteLine("Alert!!Now is " + i);
         };

        public Action<int> ShowMes = (i) =>
        {
            Console.WriteLine("Display!!Now is " + i);
        };

        public event Action<int> Boiler;

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i >= 95)
                {
                    this.Boiler = this.MakeAlert;
                    this.Boiler += this.ShowMes;
                    Boiler(i);
                }
            }

        }
    }
}
