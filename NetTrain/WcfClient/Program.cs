using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();

            // 使用 "client" 变量在服务上调用操作。
            var temp = client.GetData(1);
            Console.WriteLine(temp);

            // 始终关闭客户端。
            client.Close();

            Console.ReadKey();
        }
    }
}
