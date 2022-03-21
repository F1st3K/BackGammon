using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BackGammon
{
    internal class RandomButton
    {
        public RandomButton(GameEvents Event)
        {
            this.Event = Event;
        }
        private GameEvents Event;
        private Random rnd = new Random();
        public Label RandLabel1;
        public Label RandLabel2;
        public void ClickOn()
        {
            this.Event.NumDice1 = rnd.Next(1, 7);
            this.Event.NumDice2 = rnd.Next(1, 7);
            ViewBackImage();
        }
        private void ViewBackImage()
        {
            RandLabel1.BackgroundImage = new Bitmap(new Bitmap(@"..\image\k" + Convert.ToString(this.Event.NumDice1) + ".png"));
            RandLabel2.BackgroundImage = new Bitmap(new Bitmap(@"..\image\k" + Convert.ToString(this.Event.NumDice2) + ".png"));
        }
    }
}
