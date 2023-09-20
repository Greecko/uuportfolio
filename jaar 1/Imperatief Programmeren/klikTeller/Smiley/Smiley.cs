using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "MondriaanC";
scherm.ClientSize = new Size(300, 300);
Bitmap plaatje = new Bitmap(300, 300);
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(300, 300);
afbeelding.BackColor = Color.White;
afbeelding.Image = plaatje;
Graphics gr = Graphics.FromImage(plaatje);

int ellipsePX = 50;
int ellipsePY = 50;
int ellipseSize = 200;
Pen pen = new Pen(color: Color.Black, ellipseSize/30);



gr.FillEllipse(Brushes.Yellow, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
gr.DrawEllipse(pen, ellipsePX, ellipsePY, ellipseSize, ellipseSize);
gr.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize/4), (ellipsePY + ellipseSize/4), ellipseSize / 10, ellipseSize / 10);
gr.FillEllipse(Brushes.Black, (ellipsePX + ellipseSize - ellipseSize/3), (ellipsePY + ellipseSize / 4), ellipseSize / 10, ellipseSize / 10);
gr.DrawArc(pen, (ellipsePX + ellipseSize/4), (ellipsePY + ellipseSize/2), (ellipseSize/2), (ellipseSize/3), 0, 180);


Application.Run(scherm);

