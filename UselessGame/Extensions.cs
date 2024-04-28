using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UselessGame
{
    internal static class Extensions
    {
        public static ICollection<Control> GetCollection(this Control.ControlCollection collection)
        {
            List<Control> output = new();
            foreach (Control control in collection)
            {
                output.Add(control);
            }
            return output;
        }
    }
}
