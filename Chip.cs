using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGammon
{
    internal class Chip : Button
    {
        public int Owner { get; private set; }
        public int CordArrayI;
        public int CordArrayJ;
        public Chip(int Owner, int i, int j)
        {
            this.Owner = Owner;
            this.CordArrayI = i;
            this.CordArrayJ = j;
        }
        public bool MayBeSteps(int[,] map)
        {
            return TopPass(map) && ExistPossibleSteps(map);
        }
        private bool TopPass(int[,] map)
        {
            if (Owner == 1 && map[CordArrayI, CordArrayJ+1] == 0)
                return true;
            if (Owner == 2 && map[CordArrayI, CordArrayJ - 1] == 0)
                return true;
            return false;
        }
        private bool ExistPossibleSteps(int[,] map)
        {
            return false;
        }
    }
}
