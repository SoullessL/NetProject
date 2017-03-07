using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    enum HotelStatus
    {
        booking = 1,
        canceling = 2,
        completing = 5
    }

    [Record("Jay", Memo = "This is Jay custom attribute one.")]
    [Record("JayTwo", Memo = "This is Jay custom attribute two.")]
    public class GetEnumToDic<T>
    {
        public static Dictionary<int, string> GetDic()
        {
            Type enumType = typeof(T);
            FieldInfo[] fields = enumType.GetFields();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (var field in fields)
            {
                if (!field.IsSpecialName)
                {
                    dic.Add(Convert.ToInt32(field.GetRawConstantValue()), field.Name);
                }
            }

            return dic;
        }
    }
}
