using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "MondriaanC";
scherm.ClientSize = new Size(600, 400);

PictureBox pictureBox = new PictureBox();
pictureBox.Location = new Point(0, 0);
pictureBox.Size = new Size(400, 400);
scherm.Controls.Add(pictureBox);

Bitmap plaatje = new Bitmap(400, 400);
pictureBox.Image = plaatje;

Graphics gr = Graphics.FromImage(plaatje);
gr.FillRectangle(Brushes.LightGreen, 0, 0, 400, 400);

Label error = new Label();
error.Text = "Invalid Inputs";
error.ForeColor = Color.Red;
error.Visible = false;
error.Location = new Point(450, 25);
scherm.Controls.Add(error);

Label info1 = new Label();
info1.Text = "x-coördinate";
info1.ForeColor = Color.Black;
info1.Location = new Point(450, 50);
scherm.Controls.Add(info1);

TextBox box1 = new TextBox();
box1.Location = new Point(450, 75);
box1.Width = 75;
scherm.Controls.Add(box1);

Label info2 = new Label();
info2.Text = "y-coördinate";
info2.ForeColor = Color.Black;
info2.Location = new Point(450, 150);
scherm.Controls.Add(info2);

TextBox box2 = new TextBox();
box2.Location = new Point(450, 175);
box2.Width = 75;
scherm.Controls.Add(box2);

Label info3 = new Label();
info3.Text = "size";
info3.ForeColor = Color.Black;
info3.Location = new Point(450, 250);
scherm.Controls.Add(info3);

TextBox box3 = new TextBox();
box3.Location = new Point(450, 275);
box3.Width = 75;
scherm.Controls.Add(box3);

Button confirm = new Button();
confirm.Location = new Point(400, 325);
confirm.Width = 200;
confirm.Height = 75;
confirm.Text = "CONFIRM";

scherm.Controls.Add(confirm);

void SmileyDraw(int ellipsePX, int ellipsePY, int ellipseSize)
{
    Graphics g = Graphics.FromImage(plaatje);

    Pen pen = new Pen(color: Color.Black, ellipseSize / 30);
    g.FillEllipse(Brushes.Yellow, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
    g.DrawEllipse(pen, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
    g.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize / 4), (ellipsePY + ellipseSize / 4), ellipseSize / 10, ellipseSize / 10);
    g.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize - ellipseSize / 3), (ellipsePY + ellipseSize / 4), ellipseSize / 10, ellipseSize / 10);
    g.DrawArc(pen, (ellipsePX + ellipseSize / 4), (ellipsePY + ellipseSize / 2), (ellipseSize / 2), (ellipseSize / 3), 0, 180);

    pictureBox.Refresh();
}

void ButtonClicked(object sender, EventArgs e)
{
    if (int.TryParse(box1.Text, out int ellipsePX) &&
        int.TryParse(box2.Text, out int ellipsePY) &&
        int.TryParse(box3.Text, out int ellipseSize))
    {
        SmileyDraw(ellipsePX, ellipsePY, ellipseSize);
        error.Visible = false;
    }
    else
    {
        error.Visible = true;
    }
}

confirm.Click += ButtonClicked;

Application.Run(scherm);
