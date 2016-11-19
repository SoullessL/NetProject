using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEFInterface;

namespace MEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationCatalog ac = new ApplicationCatalog();
            CompositionContainer cc = new CompositionContainer(ac);
            AllPokemons all = new AllPokemons();
            cc.ComposeParts(all);
            all.Pi.Show();

            Console.ReadKey();
        }
    }

    public class AllPokemons
    {
        [Import("Pi")]
        public IPokemon Pi;

        [Import("Bao")]
        public IPokemon Bao;
    }
}
