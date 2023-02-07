using System;
using System.Linq;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); 
            reset();
            nameP1.Text = nameP2.Text = Form1.form1Instance.tbx.Text;
        }

        char f1, f2, f3, f4, f5, f6, f7, f8, f9;
        byte clicks;
        bool player = false;

        private void btnReset_Click(object sender, EventArgs e)
        {
            resign();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            switch (pb.Name)
            {
                case "pB1":
                    f1 = click(f1, pb);
                    break;
                case "pB2":
                    f2 = click(f2, pb);
                    break;
                case "pB3":
                    f3 = click(f3, pb);
                    break;
                case "pB4":
                    f4 = click(f4, pb);
                    break;
                case "pB5":
                    f5 = click(f5, pb);
                    break;
                case "pB6":
                    f6 = click(f6, pb);
                    break;
                case "pB7":
                    f7 = click(f7, pb);
                    break;
                case "pB8":
                    f8 = click(f8, pb);
                    break;
                case "pB9":
                    f9 = click(f9, pb);
                    break;
            }
            win();
        }

        char click(char field, PictureBox pB)
        {
            if (field == 'n' && player == false)
            {
                pB.Image = Properties.Resources.X;
                pB.Refresh();
                field = 'x';
                clicks++;
                player = true;
            }
            else if (field == 'n' && player)
            {
                pB.Image = Properties.Resources.O;
                pB.Refresh();
                field = 'o';
                clicks++;
                player = false;
            }
            return field;
        }
        void reset()
        {
            pB1.Image = pB2.Image = pB3.Image = pB4.Image = pB5.Image = pB6.Image = pB7.Image = pB8.Image = pB9.Image = Resources.None;
            pB1.Refresh(); pB2.Refresh(); pB3.Refresh(); pB4.Refresh(); pB5.Refresh(); pB6.Refresh(); pB7.Refresh(); pB8.Refresh(); pB9.Refresh();
            f1 = f2 = f3 = f4 = f5 = f6 = f7 = f8 = f9 = 'n';
            clicks = 0;
            player = false;
        }
        void resign()
        {
            reset();
            labelScoreP1.Text = labelScoreP2.Text = "0";
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Close();
        }
        bool hasWon(char symbol)
        {
            char[][] winChecks = new char[][]
            {
                new char[] {f1, f2, f3 },
                new char[] {f4, f5, f6 },
                new char[] {f7, f8, f9 },
                new char[] {f1, f5, f9 },
                new char[] {f4, f5, f7 },
                new char[] {f1, f4, f7 },
                new char[] {f2, f5, f8 },
                new char[] {f4, f6, f9 },
            };

            foreach (var winCheck in winChecks)
            {
                if (winCheck.All(str => str == symbol))
                {
                    return true;
                }
            }
            return false;
        }
        void win()
        {
            if (hasWon('x'))
            {
                labelScoreP1.Text = Convert.ToString(Convert.ToByte(labelScoreP1.Text) + 1);
                MessageBox.Show("Red has won!");
                reset();
            }
            if (hasWon('o'))
            {
                labelScoreP2.Text = Convert.ToString(Convert.ToByte(labelScoreP2.Text) + 1);
                MessageBox.Show("Blue has won!");
                reset();
            }
            if (clicks == 9)
            {
                MessageBox.Show("Tie!");
                reset();
            }
        }
    }
}