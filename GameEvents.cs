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
        public int NumDice = 3;
        public int[,] map;
        public MainField Field;
        public RandomButton RandBtn;
        private bool IsMoving = false;
        public int CurrentPlayer { get; private set; } = 1;
        public void OnPressButton(object sender, EventArgs e)
        {
            if (sender is Chip)
            {
                Chip pressedButton = sender as Chip;
                ShowButton(pressedButton);
                if (NumDice == 0)
                {
                    CurrentPlayer = SwitchPlayer(CurrentPlayer);
                }
                pressedButton.Field = Field;
                IsMoving = pressedButton.MayBeSteps(map, NumDice, CurrentPlayer);
                prevButton = pressedButton;
                return;
            }
            if (IsMoving && prevButton is Chip)
            {
                Button pressedButton = sender as Button;
                Move(pressedButton, prevButton);
                sender = prevButton;
                this.OnPressButton(sender, e);
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
            NumDice--;
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