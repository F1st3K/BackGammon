using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BackGammon
{
    internal class GameEvents
    {
        private Chip prevButton;
        public int NumDice1 = 0;
        public int NumDice2 = 0;
        public int[,] map;
        public MainField Field;
        public RandomButton RandBtn;
        private bool IsMoving = false;
        private int coff = 1;
        private bool HouseOpenWhite = false;
        private bool HouseOpenBlack = false;
        private bool HouseFullWhite = false;
        private bool HouseFullBlack = false;
        public int CurrentPlayer { get; private set; } = 2;
        public GameEvents()
        {
            
        }
        public void OnPressButton(object sender, EventArgs e)
        {
            if (sender is Chip)
            {
                Chip pressedButton = sender as Chip;
                ShowButton(pressedButton);
                CheckGameStatus();
                if (NumDice1 == 0 && NumDice2 == 0)
                {
                    CurrentPlayer = SwitchPlayer(CurrentPlayer);
                }
                pressedButton.Field = Field;
                if (CurrentPlayer == 2)
                    pressedButton.HouseFull = HouseFullBlack;
                else
                    pressedButton.HouseFull = HouseFullWhite;
                bool MayStep1 = pressedButton.MayBeSteps(map, NumDice1, CurrentPlayer);
                bool MayStep2 = pressedButton.MayBeSteps(map, NumDice2, CurrentPlayer);
                IsMoving = MayStep1 || MayStep2;
                prevButton = pressedButton;
                return;
            }
            if (IsMoving && prevButton is Chip)
            {
                Button pressedButton = sender as Button;
                ScoreStep(pressedButton, prevButton);
                Move(pressedButton, prevButton);
                sender = prevButton;
                this.OnPressButton(sender, e);
            }
        }
        private void CheckGameStatus()
        {
            bool HouseOpen = CurrentPlayer == 2 ? HouseOpenBlack : HouseOpenWhite;
            int quantity = InHousePlayer();
            if (!HouseOpen && quantity != 0)
            {
                HouseOpen = true;
                if (CurrentPlayer == 2)
                    HouseOpenBlack = HouseOpen;
                else
                    HouseOpenWhite = HouseOpen;
            }
            bool HouseFull = CurrentPlayer == 2 ? HouseFullBlack : HouseFullWhite;
            if (!HouseFull && quantity == 15)
            {
                HouseFull = true;
                if (CurrentPlayer == 2)
                    HouseFullBlack = HouseFull;
                else
                    HouseFullWhite = HouseFull;
            }
        }
        private int InHousePlayer()
        {
            int quantity = 0;
            int[,] cells = { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
            if (CurrentPlayer == 2)
            {
                int j = 0;
                int i = 0;
                for (int n = 0; n < 6; n++)
                {
                    cells[n, 0] = i;
                    cells[n, 1] = j;
                    i++;
                }
            }
            else
            {
                int j = 23;
                int i = 6;
                for (int n = 0; n < 6; n++)
                {
                    cells[n, 0] = i;
                    cells[n, 1] = j;
                    i++;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int n = 0;
                while (map[cells[i, 0], cells[i, 1] + n] == CurrentPlayer)
                {
                    quantity++;
                    if (CurrentPlayer == 2)
                        n++;
                    else
                        n--;
                }
            }
            return quantity;
        }
        private void ScoreStep(Button pressedButton, Chip prevButton)
        {
            if (pressedButton.Name == prevButton.PossibleStep1.Name)
            {
                if (NumDice1 == 0)
                    if (1 < coff)
                        coff--;
                    else
                        NumDice2 = 0;
                if (NumDice1 == NumDice2)
                {
                    coff = 3;
                }
                NumDice1 = 0;
                prevButton.PossibleStep1 = null;
                prevButton.PossibleStep2 = null;
            }
            else if (pressedButton.Name == prevButton.PossibleStep2.Name)
            {
                NumDice2 = 0;
                prevButton.PossibleStep1 = null;
                prevButton.PossibleStep2 = null;
            }

        }
        private void Move(Button pressedButton, Chip prevButton)
        {
            

            string prevName = prevButton.Name;
            prevButton.Name = pressedButton.Name;
            pressedButton.Name = prevName;

            Field.map[prevButton.CordArrayI, prevButton.CordArrayJ] = 0;

            prevButton.CordArrayI = Convert.ToInt16(prevButton.Name.Substring(0, prevButton.Name.IndexOf(":")));
            prevButton.CordArrayJ = Convert.ToInt16(prevButton.Name.Substring(prevButton.Name.IndexOf(":") +1));

            Field.map[prevButton.CordArrayI, prevButton.CordArrayJ] = CurrentPlayer;

            Point prevLocation = prevButton.Location;
            prevButton.Location = pressedButton.Location;
            pressedButton.Location = prevLocation;
        }
        private void ShowButton(Chip pressedButton)
        {
            ClearView();
            pressedButton.BackColor = Color.Gray;
            
        }
        private void ClearView()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    (Field.Controls[i + ":" + j] as Button).BackColor = Color.White;
                }
            }
        }
        public int SwitchPlayer(int player)
        {
            RandBtn.ClickOn();
            return player == 1 ? 2 : 1;
        }
    }
}