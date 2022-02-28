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
        private int NumDice = 3;
        public int[,] map;
        public MainField Field;
        private bool IsMoving = false;
        public void OnPressButton(object sender, EventArgs e)
        {
            if (sender is Chip)
            {
                Chip pressedButton = sender as Chip;
                ShowButton(pressedButton);
                pressedButton.Field = Field;
                pressedButton.MayBeSteps(map, NumDice);
                prevButton = pressedButton;
                IsMoving = true;
                return;
            }
            if (IsMoving && prevButton != null)
            {
                Button pressedButton = sender as Button;
                Move(pressedButton, prevButton);

                if (NumDice == 0)
                {
                    IsMoving = false;
                }
            }
        }
        private void Move(Button pressedButton, Chip prevButton)
        {
            string prevName = prevButton.Name;
            prevButton.Name = pressedButton.Name;
            pressedButton.Name = prevName;

            prevButton.CordArrayI = Convert.ToInt16(prevButton.Name.Substring(0, prevButton.Name.IndexOf(":")));
            prevButton.CordArrayJ = Convert.ToInt16(prevButton.Name.Substring(prevButton.Name.IndexOf(":") +1));

            Point prevLocation = prevButton.Location;
            prevButton.Location = pressedButton.Location;
            pressedButton.Location = prevLocation;
            NumDice--;
        }
        private void ShowButton(Chip pressedButton)
        {
            pressedButton.BackColor = Color.Gray;
            if (prevButton != null)
                prevButton.BackColor = Color.White;
        }
    }
}