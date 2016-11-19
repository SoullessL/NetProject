using System;
using Autofac;

namespace AutoFacTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/********************One********************/");
            //单个class的注入，并且使用单例用构造函数赋值
            var builder = new ContainerBuilder();
            builder.RegisterType<Master>().SingleInstance();
            using (var container = builder.Build())
            {
                var master = container.Resolve<Master>(new NamedParameter("name", "Jay"));
                master.Show();
                var master2 = container.Resolve<Master>(new NamedParameter("name", "T"));
                master2.Show();
                master.Name = "3";
                master2.Show();
            }

            Console.WriteLine("/********************Two********************/");
            //多个class继承同一个接口
            var conBuilder = new ContainerBuilder();
            conBuilder.RegisterType<BaoLiLong>().As<IPokenmon>();
            conBuilder.RegisterType<BiKaQiu>().As<IPokenmon>();
            using (var container=conBuilder.Build())
            {
                //注册同一个接口，调用的时候以后面的方法为主,这里调用的就是后注册的 BiKaQiu
                var biKaQiu = container.Resolve<IPokenmon>();
                biKaQiu.Zhaoshi();
                //报错
                //var baoLiLong = container.Resolve<BaoLiLong>();
                //baoLiLong.Zhaoshi();
            }

            Console.WriteLine("/********************Three******************/");
            //多个class继承同一个接口
            var tb = new ContainerBuilder();
            tb.RegisterType<BaoLiLong>().Named<IPokenmon>("BaoLiLong");
            tb.RegisterType<BiKaQiu>().Named<IPokenmon>("BiKaQiu");
            using (var container = tb.Build())
            {
                var biKaQiu = container.ResolveNamed<IPokenmon>("BiKaQiu");
                biKaQiu.Zhaoshi();
                var baoLiLong = container.ResolveNamed<IPokenmon>("BaoLiLong");
                baoLiLong.Zhaoshi();
            }

            Console.ReadKey();
        }
    }

    class Master
    {
        public string Name { get; set; }

        public Master(string name)
        {
            this.Name = name;
        }

        public void Show()
        {
            Console.WriteLine("I'm pokemon master " + this.Name);
        }
    }

    interface IPokenmon
    {
        void Zhaoshi();

        void LeiBie();
    }

    class BiKaQiu : IPokenmon
    {
        public void Zhaoshi()
        {
            Console.WriteLine("I can Thunderbolt.");
        }

        public void LeiBie()
        {
            Console.WriteLine("I'm lei xi.");
        }
    }

    class BaoLiLong : IPokenmon
    {
        public void Zhaoshi()
        {
            Console.WriteLine("I can langji.");
        }

        public void LeiBie()
        {
            Console.WriteLine("I'm shui xi.");
        }
    }
}
