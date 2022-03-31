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
        public MainField Field;
        public Button PossibleStep1;
        public Button PossibleStep2;
        public int PossibleDice1 = 0;
        public int PossibleDice2 = 0;
        public bool HouseFull;
        public int NumSteps { get; private set; }
        public Chip(int Owner, int i, int j)
        {
            this.Owner = Owner;
            this.CordArrayI = i;
            this.CordArrayJ = j;
        }
        public bool MayBeSteps(int[,] map, int NumDice, int CurrentPlayer)
        {
            return Owner == CurrentPlayer && TopPass(map) && ExistPossibleSteps(map, NumDice);
        }
        private bool TopPass(int[,] map)
        {
            if ((CordArrayJ == 23 && map[CordArrayI, CordArrayJ - 1] == 0) ||
                (CordArrayJ == 0  && map[CordArrayI, CordArrayJ + 1] == 0) ||
                (CordArrayJ != 23 && map[CordArrayI, CordArrayJ + 1] == 0) ||
                (CordArrayJ != 0  && map[CordArrayI, CordArrayJ - 1] == 0))
                return true;
            return false;
        }
        private bool ExistPossibleSteps(int[,] map, int NumDice)
        {
            if (NumDice != 0)
                PossibleSteps(map, NumDice);
            if (NumSteps != 0)
            {
                NumSteps = 0;
                return true;
            }
            return false;
        }
        private void PossibleSteps(int[,] map, int NumDice)
        {
            if (StayFlat(map, NumDice))
                return;
            if (RunNextFlat(map, NumDice))
                return;
            if (StayNextFlat(map, NumDice))
                return;
            if (HouseFull)
                DropNextFlat(map, NumDice);
                return;
        }
        private bool StayFlat(int[,] map, int NumDice)
        {
            int j = 23;
            int maxI = 11;
            int i = CordArrayI;
            int start = 23;
            if (Owner == 1)
            {
                start = 0;
                j = 0;
                i = -CordArrayI;
                maxI = 0;
            }
            if ((CordArrayJ == start || map[Math.Abs(i), start] == Owner) && i + NumDice <= maxI)
            {
                if (map[Math.Abs(i + NumDice), j] == Owner || map[Math.Abs(i + NumDice), j] == 0)
                {
                    ShowButton(Math.Abs(i + NumDice), j, NumDice, map);
                    NumSteps++;
                }
                return true;
            }
            return false;
        }
        private bool RunNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 11;
            int i = CordArrayI;
            int start = 23;
            if (Owner == 1)
            {
                j = 23;
                i = -CordArrayI;
                maxI = 0;
                start = 0;

            }
            if ((j == start || map[Math.Abs(i), start] == Owner) && i + NumDice > maxI)
            {
                if (map[11 - Math.Abs((i + NumDice - 12)), j] == Owner || map[11 - Math.Abs((i + NumDice - 12)), j] == 0)
                {
                    ShowButton(11 - Math.Abs((i + NumDice - 12)), j, NumDice, map);
                    NumSteps++;
                }
                return true;
            }
            return false;
        }
        private bool StayNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 0;
            int i = CordArrayI;
            int end = 0;
            if (Owner == 1)
            {
                j = 23;
                i = -CordArrayI;
                maxI = -11;
                end = 23;

            }
            if ((j == end || map[Math.Abs(i), end] == Owner) && i - NumDice >= maxI)
            {
                if (map[Math.Abs(i - NumDice), j] == Owner || map[Math.Abs(i - NumDice), j] == 0)
                {
                    ShowButton(Math.Abs(i - NumDice), j, NumDice, map);
                    NumSteps++;
                }
                return true;
            }
            return false;
        }
        private void DropNextFlat(int[,] map, int NumDice)
        {
            
        }
        private void ShowButton(int i, int j, int NumDice, int [,] map)
        {
            (i, j) = CheckForChips(i, j, map);
            (Field.Controls[i + ":" + j] as Button).BackColor = Color.Yellow;
            (Field.Controls[i + ":" + j] as Button).Enabled = true;
            AddStepPossible((Field.Controls[i + ":" + j] as Button), NumDice);
        }
        private (int, int) CheckForChips(int i, int j, int [,] map)
        {
            int coff = 0;
            if (map[i, j] == Owner)
            {
                if (j == 0 || (map[i, j - 1] == Owner && j != 23))
                {
                    coff = 1;
                }
                else if (j == 23 || map[i, j + 1] == Owner)
                {
                    coff = -1;
                }
                for (; ;j += coff )
                {
                    if (map[i, j] == 0)
                        break;
                }
            }
            return (i, j);
        }
        private void AddStepPossible(Button PosBtn, int NumDice)
        {
            if (PossibleStep1 == null)
            {
                PossibleStep1 = PosBtn;
            }
            else if (PossibleStep2 == null)
            {
                PossibleStep2 = PosBtn;
            }

        }
    }
}
