using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<PiKaQiu> pi = new Lazy<PiKaQiu>();
            Console.WriteLine(pi);
            pi.Value.Name = "Jay";
            pi.Value.Show();

            Console.ReadKey();
        }
    }

    public class PiKaQiu
    {
        public string Name { get; set; }

        public void Show()
        {
            Console.WriteLine("This is PiKaQiu:" + this.Name);
        }
    }
}
