using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RecordAttribute : Attribute
    {
        public string Author { get; }

        public string Memo { get; set; }

        public RecordAttribute(string author)
        {
            this.Author = author;
        }
    }
}
