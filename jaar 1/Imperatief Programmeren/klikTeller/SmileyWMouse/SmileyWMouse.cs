using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

Form scherm = new Form();
scherm.ClientSize = new Size(800, 600);
scherm.Text = "Smiley met muis";

Point hier = new Point(0, 0);

void Determinexy(object sender, MouseEventArgs mea) {
    hier = mea.Location;
    scherm.Invalidate();
}

void SmileyDraw(int ellipsePX, int ellipsePY, Graphics g) {

    int ellipseSize = 20;

    Pen pen = new Pen(color: Color.Black, ellipseSize / 30);
    g.FillEllipse(Brushes.Yellow, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
    g.DrawEllipse(pen, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
    g.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize / 4), (ellipsePY + ellipseSize / 4), ellipseSize / 10, ellipseSize / 10);
    g.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize - ellipseSize / 3), (ellipsePY + ellipseSize / 4), ellipseSize / 10, ellipseSize / 10);
    g.DrawArc(pen, (ellipsePX + ellipseSize / 4), (ellipsePY + ellipseSize / 2), (ellipseSize / 2), (ellipseSize / 3), 0, 180);
}

void Paintcall(object o, PaintEventArgs pea) {
    Graphics g = pea.Graphics;
    int x = hier.X;
    int y = hier.Y;

    SmileyDraw(x, y, g);
}

scherm.MouseClick += Determinexy;
scherm.Paint += Paintcall;

//nice!

Application.Run(scherm);