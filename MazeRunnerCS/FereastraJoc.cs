using System;
using System.Collections.Generic;
using System.Drawing;
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

        private bool gameStart = false;
        private int margineInterioaraWidth;
        private int margineInterioaraHeight;
        private Point punctZero;

        private int xLatura2;
        private int xLatura1;
        private int yLatura2;
        private int yLatura1;

        private int vieti = 3;

        private List<Coordonate> coordonate = new List<Coordonate>();
        private List<PictureBox> mancaruri = new List<PictureBox>();
        


        //TODO: Cum calculam victoria jucatorului
        //Am putea sa folosim sistemul de coordonate cu punctul de origine aflat in coltul de stanga sus
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
            label1.BackColor = Color.Transparent;
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

            GenerareMancare();
        }

        private Color getPixelFromImage(int x, int y)
        {
            Bitmap map = new Bitmap(labirint.Size.Width, labirint.Size.Height);
            labirint.DrawToBitmap(map, labirint.ClientRectangle);
            Color color = map.GetPixel(x, y);
            return color;

        }

        private bool verificaCuloare(int x, int y)
        {
            Color culoareOrigine = getPixelFromImage(x, y);
            Color culoareColtDreaptaSus = getPixelFromImage(x + 14, y);
            Color culoareColtDreaptaJos = getPixelFromImage(x + 14, y + 14);
            Color culoareColtStangaJos = getPixelFromImage(x, y + 14);
            Color[] culori = new Color[]
            {
                culoareColtDreaptaJos,
                culoareColtDreaptaSus,
                culoareColtStangaJos,
                culoareOrigine
            };

            foreach (var color in culori)
            {
                if (color == Color.FromArgb(255, 63, 63, 63)) return false;
                if (color == Color.FromArgb(255, 0, 0, 0)) return false;
                if (color == Color.FromArgb(255, 191, 191, 191)) return false;
                if (color == Color.FromArgb(255, 239, 239, 239)) return false;
            }
            

            return true;
        }
        private void GenerareMancare()
        {

            Random random = new Random();



            for (int i = 0; i < 10; i++)
            {
                int x, y;
                x = random.Next(5, 428);
                y = random.Next(5, 430);
                while (verificaCuloare(x,y) == false)
                {
                    x = random.Next(5, 428);
                    y = random.Next(5, 430);
                }
                coordonate.Add(new Coordonate
                {
                    X = x,
                    Y = y,
                });


                coordonate[i].CentruX = coordonate[i].X + 7;
                coordonate[i].CentruY = coordonate[i].Y + 7;
            }
            Image image = caracter.Image;
            for (int i = 0; i < 10; i++)
            {

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.BackColor = Color.Red;
                pictureBox.Size = new Size(15, 15);
                pictureBox.Location = new Point(coordonate[i].X, coordonate[i].Y);
                pictureBox.Show();
                labirint.Controls.Add(pictureBox);

                mancaruri.Add(pictureBox);

            }
        }

        private void atingeMancarea()
        {
            foreach (var mancare in mancaruri)
            {
                if (IsTouching(mancare))
                {
                    mancare.Dispose();
                    break;
                }
            }
        }

        private bool IsTouching(PictureBox mancare)
        {
            if (caracter.Location.X + caracter.Width < mancare.Location.X)
                    return false;
                if (mancare.Location.X + mancare.Width < caracter.Location.X)
                    return false;
                if (caracter.Location.Y + caracter.Height < mancare.Location.Y)
                    return false;
                if (mancare.Location.Y + mancare.Height < caracter.Location.Y)
                    return false;
            vieti++;
            mancaruri.Remove(mancare);
            mancare.Dispose();

            return true;
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
            label1.Text = $"Game started!\nLifes: {vieti}";
            label1.BackColor = Color.Transparent;
        }

        private void afisareDetaliiJoc()
        {
            label1.Text = $"Game started!\nLifes: {vieti}";
            label1.BackColor = Color.Transparent;
        }

        private void labirint_Resize(object sender, EventArgs e)
        {

        }

        private void FereastraJoc_SizeChanged(object sender, EventArgs e)
        {

        }

        private void caracter_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameStart)
            {
                afisareDetaliiJoc();
                if(e.Location.X <= 2)
                {
                    caracter.Location = new Point(caracter.Location.X - 2, caracter.Location.Y);
                }
                else if(e.Location.X >= 27)
                {
                    caracter.Location = new Point(caracter.Location.X + 2, caracter.Location.Y);
                }
                if(e.Location.Y >= 23)
                {
                    caracter.Location = new Point(caracter.Location.X, caracter.Location.Y + 2);
                }
                else if (e.Location.Y <= 2)
                {
                    caracter.Location = new Point(caracter.Location.X, caracter.Location.Y - 2);
                }
                atingeMancarea();
            }
        }
    }

    public class Coordonate
    {
        public int X, Y, CentruX, CentruY;
    }
}
 