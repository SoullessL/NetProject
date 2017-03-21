using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    class Program
    {
        public class CallbackHandler : IService1Callback
        {
            public void PrintSomeThing(string str)
            {
                Console.WriteLine("This is client ." + str);
            }
        }

        static void Main(string[] args)
        {
            var callback = new CallbackHandler();
            InstanceContext con = new InstanceContext(callback);
            Service1Client client = new Service1Client(con);

            DuplexChannelFactory<IService1> fac = new DuplexChannelFactory<IService1>(con, "WSDualHttpBinding_IService1");
            var ser = fac.CreateChannel();
            Console.WriteLine(ser.GetData(3));


            // 使用 "client" 变量在服务上调用操作。
            var temp = client.GetData(1);

            Console.WriteLine(temp);

            // 始终关闭客户端。
            client.Close();

            Console.ReadLine();

        }
    }
}
