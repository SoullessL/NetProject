using System;
using System.ComponentModel.Composition;
using MEFInterface;

namespace MEFImplement
{
    [Export("Pi",typeof(IPokemon))]
    public class PiKaQiu:IPokemon
    {
        public void Show()
        {
            Console.WriteLine("This is PiKaQiu.");
        }
    }

    [Export("Bao",typeof(IPokemon))]
    public class BaoLiLong : IPokemon
    {
        public void Show()
        {
            Console.WriteLine("This is BaoLiLong.");
        }
    }
}
