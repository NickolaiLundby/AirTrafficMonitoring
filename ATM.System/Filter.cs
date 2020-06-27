using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.System
{
    public class Filter
    {
        public bool CheckXY(int x, int y)
        {
            if (x < 1000 || y < 1000 || x > 11000 || y > 11000)
                return false;
            else
            {
                return true;
            }
        }
    }
}
