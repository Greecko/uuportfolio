using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Eyes";
scherm.ClientSize = new Size(800, 600);
scherm.BackColor = Color.Yellow;

Point mousePoint = new Point(0, 0);

//ellipse&oog constanten:
int oogGrootte = 30;
int xE = 150;
int yE = 150;
int grootteE = 300;

int grootteOog = 30;
int xEMidden = xE + (grootteE / 2);
int yEMidden = yE + (grootteE / 2);


void Adjust(object o, MouseEventArgs mea) {
    mousePoint = mea.Location;
    scherm.Invalidate();
}

void teken(object o, PaintEventArgs pea, int oogGrootte, int xE, int yE, int grootteE, int grootteOog, int xEMidden, int yEMidden) {

    double dx = mousePoint.X - xEMidden;
    double dy = mousePoint.Y - yEMidden;
    double d = Math.Sqrt(dx * dx + dy * dy);
    double e = grootteOog / 2 - grootteE/2;
    double eX = -dx * (e / d);
    double eY = -dy * (e / d);


    Graphics g = pea.Graphics;
    Pen pen = new Pen(color: Color.Black, 5);
    g.DrawEllipse(pen, xE, yE, grootteE, grootteE);
    g.FillEllipse(Brushes.Blue, xEMidden + (int)eX - (grootteOog/2), yEMidden + (int)eY - (grootteOog/2), grootteOog, grootteOog);

}



scherm.MouseMove += Adjust;
scherm.Paint += (sender, p) => teken(sender, p, grootteOog, xE, yE, grootteE, grootteOog, xEMidden, yEMidden);
scherm.Paint += (sender, p) => teken(sender, p, grootteOog, xE*3, yE, grootteE, grootteOog, xEMidden*2, yEMidden);


Application.Run(scherm);