using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace BackGammon
{
    internal class MainField:Form
    {
        private const int mapSizeX = 12;
        private const int mapSizeY = 24;
        private const int cellSizeX = 45;
        private const int cellSizeY = 27;
        private int[,] map = new int[mapSizeX, mapSizeY];
        private int paddx = (1280 - (cellSizeX * 16 + 80)) / 2;
        private int paddy = (720 - (cellSizeY * 24 + 40)) / 2;
        private Image whiteFigure = new Bitmap(new Bitmap(@"..\image\w.png"), new Size(cellSizeX - 1, cellSizeY - 1));
        private Image blackFigure = new Bitmap(new Bitmap(@"..\image\b.png"), new Size(cellSizeX - 1, cellSizeY - 1));
        public MainField()
        {
            Init();
        }
        private void Init()
        {
            map = new int[mapSizeX, mapSizeY] {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };
            DrawMap();
        }
        private void DrawMap()
        {
            //Graphics g = CreateGraphics();
            for (int i = 0; i < mapSizeX; i++)
            {
                paddx += 5;
                if (i == 6)
                    paddx += cellSizeX * 2;
                for (int j = 0; j < mapSizeY; j++)
                {
                    Button button = CheckingChip(i, j);//new Button();
                    button.Location = new Point(i * cellSizeX + paddx, j * cellSizeY + paddy);
                    button.Size = new Size(cellSizeX, cellSizeY);
                    button.BackColor = Color.White;
                    button.Name = NameButton(button, i, j);
                    button.BackgroundImage = DrowFigure(button, i, j);
                    //button.Click += new EventHandler(OnPressFigure);
                    this.Controls.Add(button);
                }
            }
        }
        private Button CheckingChip(int i, int j)
        {
            if (map[i, j] == 1)
                return new Chip(1);
            if (map[i, j] == 2)
                return new Chip(2);
            return new Button();
        }
        private string NameButton(Button button, int i, int j)
        {
            if (i < 10)
                button.Name += "0";
            button.Name += Convert.ToString(i);
            if (j < 10)
                button.Name += "0";
            button.Name += Convert.ToString(j);
            return button.Name;
        }
        private Image DrowFigure(Button button, int i, int j)
        {
            if (map[i, j] == 1)
                return button.BackgroundImage = whiteFigure;
            else if (map[i, j] == 2)
                return button.BackgroundImage = blackFigure;
            return null;
        }
}
}
