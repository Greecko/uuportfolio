using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Klik teller";
scherm.ClientSize = new Size(500, 350);
scherm.BackColor = Color.SeaGreen;

Button knop = new Button();
knop.Text = "Click Me";
knop.Location = new Point(50, 50);
scherm.Controls.Add(knop);
Label clickTimes = new Label();
clickTimes.ForeColor = Color.Blue;
clickTimes.Location = new Point(80, 80);
scherm.Controls.Add(clickTimes);


int clickCounter = 0;

void ClickHandler(object sender, EventArgs e)
{
    clickCounter++;
    clickTimes.Text = "Times clicked " + clickCounter;

    if (clickCounter == 20)
    {
        Label achievement1 = new Label();
        achievement1.ForeColor = Color.Yellow;
        achievement1.Location = new Point(120, 120);
        achievement1.Text = "Achievement 1";
        scherm.Controls.Add(achievement1);
    }
}


knop.Click += ClickHandler;

Application.Run(scherm);
