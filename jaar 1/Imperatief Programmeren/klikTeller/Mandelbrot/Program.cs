using System;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Mandelbrot";
scherm.ClientSize = new Size(420, 640);

//Label voor invoer van variable Midden X
Label textx = new Label();
scherm.Controls.Add(textx);
textx.Location = new Point(10, 20);
textx.Size = new Size(80, 20);
textx.Text = "Midden X: ";

//Invoer vak voor variable Midden X
TextBox middenxbox = new TextBox();
scherm.Controls.Add(middenxbox);
middenxbox.Location = new Point(100, 20);
middenxbox.Size = new Size(80, 20);

//Label voor invoer van variable Midden Y
Label texty = new Label();
scherm.Controls.Add(texty);
texty.Location = new Point(10, 50);
texty.Size = new Size(80, 20);
texty.Text = "Midden Y: ";

//Invoer vak voor variable Midden Y
TextBox middenybox = new TextBox();
scherm.Controls.Add(middenybox);
middenybox.Location = new Point(100, 50);
middenybox.Size = new Size(80, 20);

//Label voor invoer van variable Schaal
Label textschaal = new Label();
scherm.Controls.Add(textschaal);
textschaal.Location = new Point(10, 80);
textschaal.Size = new Size(80, 20);
textschaal.Text = "Schaal: ";

//Invoer vak voor variable Schaal
TextBox schaalbox = new TextBox();
scherm.Controls.Add(schaalbox);
schaalbox.Location = new Point(100, 80);
schaalbox.Size = new Size(80, 20);

//Label voor invoer van variable MaxAantal
Label textaantal = new Label();
scherm.Controls.Add(textaantal);
textaantal.Location = new Point(10, 110);
textaantal.Size = new Size(80, 20);
textaantal.Text = "Max Aantal: ";

//Invoer vak voor variable MaxAantal
TextBox aantalbox = new TextBox();
scherm.Controls.Add(aantalbox);
aantalbox.Location = new Point(100, 110);
aantalbox.Size = new Size(80, 20);

// Knop voor het uitvoeren van het programma
Button go = new Button();
scherm.Controls.Add(go);
go.Location = new Point(200, 110);
go.Size = new Size(80, 20);
go.Text = "GO";

//De bitamap waar het mandelbrot in komt te staan
Bitmap mandelbit = new Bitmap(400, 400);
Graphics draw = Graphics.FromImage(mandelbit);
Label mandelbrot = new Label();
scherm.Controls.Add(mandelbrot);
mandelbrot.Location = new Point(10, 220);
mandelbrot.Size = new Size(400, 400);
mandelbrot.BackColor = Color.White;
mandelbrot.Image = mandelbit;

bool isDragging = false;
int middenx = 200;
int middeny = 200;
Point initialDragPoint = Point.Empty;

//de initiale schaal van de mandelbrot
double schaal = 0.01;


//deze methode berekent het mandelgetal en kleurt de pixels
void mandelreken(object o, EventArgs e)
{
    int maxaantal = Int32.Parse(aantalbox.Text);

    for (int column = 0; column < 400; column++)
    {
        for (int row = 0; row < 400; row++)
        {

            double a = 0;
            double b = 0;
            double x = (row - middenx) * schaal;
            double y = (column - middeny) * schaal;

            int mandelgetal = 0;

            while (a * a + b * b <= 4.0 && mandelgetal < maxaantal)
            {
                //tempA is nodig om de originele waardes van a en b te gebruiken
                double tempA = a * a - b * b + x;
                b = 2 * a * b + y;
                a = tempA;
                mandelgetal++;
            }
            Color color = mandelgetal == maxaantal ? Color.Black : Color.White;

            mandelbit.SetPixel(row, column, color);
        }
    }

    mandelbrot.Refresh();
}

//hieronder zijn 3 event handlers voor het drag-and-drop mechaniek
void MBMouseUp(object sender, MouseEventArgs mea)
{

    if (mea.Button == MouseButtons.Left)
    {
        isDragging = false;
        initialDragPoint = mea.Location;
    }
}

void MBMouseMove(object sender, MouseEventArgs mea)
{

    if (isDragging)
    {
        int verschilX = mea.X - initialDragPoint.X;
        int verschilY = mea.Y - initialDragPoint.Y;

        middenx += verschilX;
        middeny += verschilY;

        mandelreken(null, EventArgs.Empty);

        initialDragPoint = mea.Location;
    }
}

void MBMouseDown(object sender, MouseEventArgs mea)
{

    if (mea.Button == MouseButtons.Left)
    {
        isDragging = true;
        initialDragPoint = mea.Location;
    }
}

//hieronder staat de event handler voor het scrollen van de scrollwheel
void MBScrollWheel(object sender, MouseEventArgs mea)
{

    double zoomFactor = mea.Delta > 0 ? 0.9 : 1.1;

    schaal *= zoomFactor;

    middenx = (int)(mea.X + (middenx - mea.X) * zoomFactor);
    middeny = (int)(mea.Y + (middeny - mea.Y) * zoomFactor);

    mandelreken(null, EventArgs.Empty);
}


mandelbrot.MouseUp += MBMouseUp;
mandelbrot.MouseDown += MBMouseDown;
mandelbrot.MouseMove += MBMouseMove;
mandelbrot.MouseWheel += MBScrollWheel;

go.Click += mandelreken;

Application.Run(scherm);