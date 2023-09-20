using System;
using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "Checksum";
scherm.BackColor = Color.LightYellow;
scherm.ClientSize = new Size(400, 300);
Label remainderL = new Label();
remainderL.Location = new Point(100, 150);
scherm.Controls.Add(remainderL);

Boolean valid = false;

int Last(int number) {
    char[] numberArray = number.ToString().ToCharArray();
    return numberArray[numberArray.Length - 1];
}
int HoeveelsteNummer(int number, int t) {
    char[] numberArray = number.ToString().ToCharArray();

    if (t < 0 || t > numberArray.Length - 1)
        return -1;

        return numberArray[t - 1];
}

int GeldigStudentnummer(int studentnummer)
{
    if (studentnummer.ToString().Length != 7) {
        valid = false;
        scherm.BackColor = Color.Red;
        return -1;
    }

    valid = true;

    if (valid) {
        scherm.BackColor = Color.Green;
    }

    char[] studentnummerAr = studentnummer.ToString().ToCharArray();


    int sum = 0;
    int count = 8;
    foreach (char c in studentnummerAr)
    {
        sum += int.Parse(c.ToString()) * (count - 1);
        count--;
    }

    int remainder = sum % 11;
    return remainder;
}

TextBox input = new TextBox();
input.Text = "input";
input.Location = new Point(200, 150);
scherm.Controls.Add(input);

void Output(object sender, EventArgs e) {
    remainderL.Text = GeldigStudentnummer(int.Parse(input.Text)).ToString();
}

input.TextChanged += Output;



Application.Run(scherm);
