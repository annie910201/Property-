using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PickAndRestriction
{
    class Enemy:Velocity
    {
        int enemyV;
        public new int getV(Color color)
        {
            if (color == Color.Blue) enemyV = 10;
            else if (color == Color.Red) enemyV = 20;
            else if (color == Color.Green) enemyV = 30;
            return enemyV;
        }
    }
}
