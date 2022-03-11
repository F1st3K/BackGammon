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
            /*if (Owner == 1 && map[CordArrayI, CordArrayJ+1] == 0)
                return true;
            if (Owner == 2 && map[CordArrayI, CordArrayJ - 1] == 0)
                return true;*/
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
            {
                NumSteps++;
                return;
            }
            if (RunNextFlat(map, NumDice))
            {
                NumSteps++;
                return;
            }
            if (StayNextFlat(map, NumDice))
            {
                NumSteps++;
                return;
            }
        }
        private bool StayFlat(int[,] map, int NumDice)
        {
            int j = 23;
            int maxI = 11;
            int i = CordArrayI;
            if (Owner == 1)
            {
                j = 0;
                i = -CordArrayI;
                maxI = 0;

            }
            if (i + NumDice <= maxI)
            {
                ShowButton(Math.Abs(i + NumDice), j, NumDice);
                return true;
            }
            return false;
        }
        private bool RunNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 11;
            int i = CordArrayI;
            if (Owner == 1)
            {
                j = 23;
                i = -CordArrayI;
                maxI = 0;

            }
            if (i + NumDice > maxI)
            {
                ShowButton(12 - Math.Abs((i + NumDice - 11)), j, NumDice);
                return true;
            }
            return false;
        }
        private bool StayNextFlat(int[,] map, int NumDice)
        {
            int j = 0;
            int maxI = 0;
            int i = CordArrayI;
            if (Owner == 1)
            {
                j = 23;
                i = -CordArrayI;
                maxI = -11;

            }
            if (i - NumDice >= maxI)
            {
                ShowButton(Math.Abs(i - NumDice), j, NumDice);
                return true;
            }
            return false;
        }
        private void ShowButton(int i, int j, int NumDice)
        {
            (Field.Controls[i + ":" + j] as Button).BackColor = Color.Yellow;
            (Field.Controls[i + ":" + j] as Button).Enabled = true;
            AddStepPossible((Field.Controls[i + ":" + j] as Button), NumDice);
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
