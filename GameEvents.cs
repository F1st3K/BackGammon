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
        public void OnPressButton(object sender, EventArgs e)
        {
            if (sender is Chip)
            {
                Chip pressedButton = sender as Chip;
                ShowButton(pressedButton);
                pressedButton.Field = Field;
                if (pressedButton.MayBeSteps(map, NumDice) && prevButton != null)
                {
                    Move(pressedButton);
                }
                prevButton = pressedButton;
            }
        }
        private void Move(Chip pressedButton)
        {

        }
        private void ShowButton(Chip pressedButton)
        {
            pressedButton.BackColor = Color.Gray;
            if (prevButton != null)
                prevButton.BackColor = Color.White;
        }
    }
}
