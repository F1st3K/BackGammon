using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BackGammon
{
    internal class Chip : Button
    {
        public int Owner { get; private set; }
        public int CordArrayI;
        public int CordArrayJ;
        
        public int NumSteps { get; private set; }
        public Chip(int Owner, int i, int j)
        {
            this.Owner = Owner;
            this.CordArrayI = i;
            this.CordArrayJ = j;
        }
        public bool MayBeSteps(int[,] map, int NumDice)
        {
            return TopPass(map) && ExistPossibleSteps(map, NumDice);
        }
        private bool TopPass(int[,] map)
        {
            if (Owner == 1 && map[CordArrayI, CordArrayJ+1] == 0)
                return true;
            if (Owner == 2 && map[CordArrayI, CordArrayJ - 1] == 0)
                return true;
            return false;
        }
        private bool ExistPossibleSteps(int[,] map, int NumDice)
        {
            PossibleSteps(map, NumDice);
            if (NumSteps != 0)
                return true;
            return false;
        }
        private void PossibleSteps(int[,] map, int NumDice)
        {
            if (StayFlat(map, NumDice))
                NumSteps++;
            if (RunNextFlat(map, NumDice))
                NumSteps++;
            if (StayNextFlat(map, NumDice))
                NumSteps++;
        }
        private bool StayFlat(int[,] map, int NumDice)
        {
            int j = 15;
            int maxI = 11;
            if (Owner == 1)
            {
                j = 0;
                CordArrayI = -CordArrayI;
                maxI = 0;

            }
            if (CordArrayI + NumDice <= maxI)
            {
                ShowButton(Math.Abs(CordArrayI + NumDice), j);
                return true;
            }
            return false;
        }
        private bool RunNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 11;
            if (Owner == 1)
            {
                j = 15;
                CordArrayI = -CordArrayI;
                maxI = 0;

            }
            if (CordArrayI + NumDice > maxI)
            {
                ShowButton(12 - Math.Abs((CordArrayI + NumDice - 11)), j);
                return true;
            }
            return false;
        }
        private bool StayNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 0;
            if (Owner == 1)
            {
                j = 15;
                CordArrayI = -CordArrayI;
                maxI = -11;

            }
            if (CordArrayI - NumDice >= maxI)
            {
                ShowButton(Math.Abs(CordArrayI - NumDice), j);
                return true;
            }
            return false;
        }
        private void ShowButton(int i, int j)
        {
            (Controls[i + ":" + j] as Button).BackColor = Color.Yellow;
            (Controls[i + ":" + j] as Button).Enabled = true;
        }
    }
}
