using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = GetEnumToDic<HotelStatus>.GetDic();
            foreach (var vaber in dic)
            {
                Console.WriteLine("Key is " + vaber.Key + ", value is " + vaber.Value + ".");
            }

            GetDicAttributeByType();
            Console.ReadLine();
        }

        private static void GetDicAttributeByType()
        {
            Type rec = typeof(GetEnumToDic<HotelStatus>);
            var allRecordAttributes = rec.GetCustomAttributes(typeof(RecordAttribute), false);
            foreach (RecordAttribute r in allRecordAttributes)
            {
                Console.WriteLine("{0}", r);
                Console.WriteLine("Author：{0}", r.Author);
                if (!String.IsNullOrEmpty(r.Memo))
                {
                    Console.WriteLine("Memo：{0}", r.Memo);
                }
            }
        }
    }
}
