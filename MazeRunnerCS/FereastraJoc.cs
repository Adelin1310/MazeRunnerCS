using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRunnerCS
{
    public partial class FereastraJoc : Form
    {
        private int _sizeX;
        private int _sizeY;
        private float _ratioX = 1.00f;
        private float _ratioY = 1.00f;
        private int gameDifficulty = 5;
        /* 5 - Hard
         * 0 - Normal
         * -5 - Easy
         */

        private bool gameStart = false;
        private int margineInterioaraWidth;
        private int margineInterioaraHeight;
        private Point punctZero;

        private int xLatura2;
        private int xLatura1;
        private int yLatura2;
        private int yLatura1;




        public FereastraJoc()
        {
            InitializeComponent();
            labirint.Image = Image.FromFile("F:\\Proiecte\\MazeRunnerCS\\MazeRunnerCS\\Resources\\labirint.png");
            caracter.Image = Image.FromFile("F:\\Proiecte\\MazeRunnerCS\\MazeRunnerCS\\Resources\\caracter.png");
            caracter.Location = new Point(caracter.Location.X, labirint.Size.Height - caracter.Size.Height);
            System.Diagnostics.Debug.WriteLine(caracter.Location.ToString());
            _sizeX = labirint.Size.Width;
            _sizeY = labirint.Size.Height;
            caracter.Size = new Size(caracter.Size.Width + gameDifficulty , caracter.Size.Height + gameDifficulty);
            label1.Text = "Click on the character to start!";

            margineInterioaraWidth = caracter.Size.Width - 4;
            margineInterioaraHeight = caracter.Size.Height - 4;

            xLatura2 = caracter.Location.X + margineInterioaraWidth;
            xLatura1 = caracter.Location.X + 2;

            yLatura2 = caracter.Location.Y + margineInterioaraHeight + 2;
            yLatura1 = caracter.Location.Y + 2;

            int pZeroX = caracter.Location.X + margineInterioaraWidth / 2 ;
            int pZeroY = caracter.Location.Y + margineInterioaraHeight / 2 ;


            punctZero = new Point(pZeroX, pZeroY);

            label1.Text += $"{punctZero.ToString()}\n" +
                $"Dreptunghi intern:\n" +
                $"XLatura1: {xLatura1} XLatura2: {xLatura2}\n" +
                $"YLatura1: {yLatura1} YLatura2: {yLatura2}";


        }

        private void FereastraJoc_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameStart)
            {

            }
        }

        private void FereastraJoc_Resize(object sender, EventArgs e)
        {

        }

        private void caracter_Click(object sender, EventArgs e)
        {
            gameStart = true;
            label1.Text = "Game started!";
        }

        private void labirint_Resize(object sender, EventArgs e)
        {
            //caracter.Location = new Point(caracter.Location.X + (labirint.Size.Width - _sizeX), caracter.Location.Y + (labirint.Size.Height - _sizeY));
            //label1.Text += $"\nLabirint: {labirint.Size.Width} x {labirint.Size.Height}\n" +
            //    $"Caracter: {caracter.Location.ToString()}";
        }

        private void FereastraJoc_SizeChanged(object sender, EventArgs e)
        {
        //    caracter.Location = new Point(caracter.Location.X + (this.Width - _sizeX), caracter.Location.Y + (this.Height - _sizeY));
        //    label1.Text += $"\nLabirint: {this.Width} x {this.Height}";
        //    this.
        }

        private void caracter_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameStart)
            {
                if(e.Location.X < xLatura1)
                {
                    caracter.Location = new Point(caracter.Location.X - (caracter.Location.X - e.X), caracter.Location.Y);
                    xLatura2 = caracter.Location.X + caracter.Size.Width - 2;
                    xLatura1 = caracter.Location.X + 2;
                }
                else if(e.Location.X > xLatura1)
                {
                    caracter.Location = new Point(caracter.Location.X + (caracter.Location.X + caracter.Size.Width - e.X), caracter.Location.Y);
                    xLatura2 = caracter.Location.X + caracter.Size.Width - 2;
                    xLatura1 = caracter.Location.X + 2;
                }
                if(e.Location.Y > yLatura2)
                {
                    caracter.Location = new Point(caracter.Location.X, caracter.Location.Y + (caracter.Location.Y + caracter.Size.Height - e.Y));
                    yLatura2 = caracter.Location.Y + caracter.Size.Height - 2;
                    yLatura1 = caracter.Location.Y + 2;
                }
                else if (e.Location.Y < yLatura1)
                {
                    caracter.Location = new Point(caracter.Location.X, caracter.Location.Y - (caracter.Location.Y + caracter.Size.Height - e.Y));
                    yLatura2 = caracter.Location.Y + caracter.Size.Height - 2;
                    yLatura1 = caracter.Location.Y + 2;
                }
            }
        }
    }
}
 