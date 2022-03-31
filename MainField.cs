using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace BackGammon
{
    partial class MainField:Form
    {
        private const int mapSizeX = 12;
        private const int mapSizeY = 24;
        private const int cellSizeX = 45;
        private const int cellSizeY = 27;
        public int[,] map = new int[mapSizeX, mapSizeY] {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} };
        private int paddx = 55;
        private int paddy = 45;
        private Image whiteFigure = new Bitmap(new Bitmap(@"..\image\w.png"), new Size(cellSizeX - 1, cellSizeY - 1));
        private Image blackFigure = new Bitmap(new Bitmap(@"..\image\b.png"), new Size(cellSizeX - 1, cellSizeY - 1));
        public MainField(GameEvents gameEvents)
        {
            gameEvents.map = map;
            DrawMap(gameEvents);
            this.Size = new System.Drawing.Size(780, 780);
            this.Text = "BackGammon";
        }
        private void DrawMap(GameEvents gameEvents)
        {
            for (int i = 0; i < mapSizeX; i++)
            {
                paddx += 5;
                if (i == 6)
                    paddx += cellSizeX+5;
                for (int j = 0; j < mapSizeY; j++)
                {
                    Button button = CheckingChip(i, j);//new Button();
                    button.Location = new Point(i * cellSizeX + paddx, j * cellSizeY + paddy);
                    button.Size = new Size(cellSizeX, cellSizeY);
                    button.BackColor = Color.White;
                    button.Name = NameButton(button, i, j);
                    button.BackgroundImage = DrowFigure(button, i, j);
                    button.Click += new EventHandler(gameEvents.OnPressButton);
                    this.Controls.Add(button);
                }
            }
            RandomButton randomBtn = new RandomButton(gameEvents, cellSizeX, cellSizeY);
            gameEvents.RandBtn = randomBtn;
            this.Controls.Add(randomBtn.RandLabel1);
            this.Controls.Add(randomBtn.RandLabel2);

            Button EdgeOfOwner1 = new Button();
            Button EdgeOfOwner2 = new Button();
            EdgeOfOwner1.Name = "EdgeWhite";
            EdgeOfOwner2.Name = "EdgeBlack";
            EdgeOfOwner1.Location = new Point(5, paddy);
            EdgeOfOwner2.Location = new Point(cellSizeX*12 + paddx + 5, cellSizeY * 14 + paddy);
            EdgeOfOwner1.Size = new Size(cellSizeX + 5, cellSizeY * 10);
            EdgeOfOwner2.Size = new Size(cellSizeX + 5, cellSizeY * 10);
            this.Controls.Add(EdgeOfOwner1);
            this.Controls.Add(EdgeOfOwner2);
        }
        private Button CheckingChip(int i, int j)
        {
            if (map[i, j] == 1)
                return new Chip(1, i, j);
            if (map[i, j] == 2)
                return new Chip(2, i, j);
            return new Button();
        }
        private string NameButton(Button button, int i, int j)
        {
            return i + ":" + j;
        }
        private Image DrowFigure(Button button, int i, int j)
        {
            if (map[i, j] == 1)
                return button.BackgroundImage = whiteFigure;
            else if (map[i, j] == 2)
                return button.BackgroundImage = blackFigure;
            return null;
        }

        /*private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainField
            // 
            this.ClientSize = new System.Drawing.Size(825, 562);
            this.Name = "MainField";
            this.Text = "BackGammon";
            this.ResumeLayout(false);

        }*/
    }
}
