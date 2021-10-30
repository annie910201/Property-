using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndRestriction
{
    class Velocity
    {
        int v;
        public int getV(Color color)
        {
            if (color == Color.Blue) v = 10;
            else if (color == Color.Red) v = 20;
            else if (color == Color.Green) v = 30;
            return v;
        }
    }
}
