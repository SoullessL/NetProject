using System;
using System.Collections;
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
            //Lazy<PiKaQiu> pi = new Lazy<PiKaQiu>();
            //Console.WriteLine(pi);
            //pi.Value.Name = "Jay";
            //pi.Value.Show();

            var suo = new SuoYin();
            foreach (PiKaQiu pika in suo)
            {
                pika.Show();
            }

            Console.ReadKey();
        }
    }


    public class SuoYin : IEnumerable
    {
        private PiKaQiu[] PiKaQius;

        public SuoYin()
        {
            PiKaQius = new PiKaQiu[] {
                new PiKaQiu(){Name="yellow" },
                new PiKaQiu(){Name="Red"}
            };
        }

        public PiKaQiu this[int i]
        {
            get
            {
                if (i < PiKaQius.Length)
                {
                    return PiKaQius[i];
                }
                else
                {
                    return new PiKaQiu();
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < PiKaQius.Length; i++)
            {
                yield return PiKaQius[i];
            }
        }
    }

    public class PiKaQiu
    {
        public string Name { get; set; }

        public void Show()
        {
            Console.WriteLine("This is PiKaQiu:" + this.Name + ".");
        }
    }
}
