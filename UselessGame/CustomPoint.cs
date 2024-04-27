using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace UselessGame
{
    public struct CustomPoint
    {
        public int X;
        public int Y;

        public CustomPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly CustomPoint Multiply(int factor) => new(X * factor, Y * factor);


    }
}
