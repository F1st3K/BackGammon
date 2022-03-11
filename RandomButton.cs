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
        public void ClickOn()
        {
            this.Event.NumDice1 = rnd.Next(1, 7);
            this.Event.NumDice2 = this.Event.NumDice1;//rnd.Next(1, 7);
        }
    }
}
