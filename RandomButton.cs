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
        public RandomButton(GameEvents Event, int cellSizeX, int cellSizeY)
        {
            this.Event = Event;
            this.RandLabel1 = new Label();
            this.RandLabel2 = new Label();
            this.RandLabel1.Location = new Point(357, 340);
            this.RandLabel2.Location = new Point(357, 290);
            this.RandLabel1.Size = new Size(cellSizeX + 5, cellSizeY * 2 - 4);
            this.RandLabel2.Size = new Size(cellSizeX + 5, cellSizeY * 2);
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
