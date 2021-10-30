using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickAndRestriction
{
    class shot:Velocity
    {
        int shotV;
        public new int getV(Color color)
        {
            if (color == Color.Blue) shotV = 10;
            else if (color == Color.Red) shotV = 20;
            else if (color == Color.Green) shotV = 30;
            return shotV;
        }
    }
}
