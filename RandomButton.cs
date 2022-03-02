using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BackGammon
{
    internal class RandomButton:Button
    {
        public RandomButton(GameEvents Event)
        {
            this.Event = Event;
        }
        private GameEvents Event;
        private Random rnd = new Random();
        private int RollDicePlayer = 1;
        public void ClickOn(object sender, EventArgs e)
        {
            if (this.Event.CurrentPlayer == RollDicePlayer)
            {
                this.Event.NumDice = rnd.Next(1, 7);
                RollDicePlayer = this.Event.SweechPlayer(RollDicePlayer);
            } 
        }
    }
}
