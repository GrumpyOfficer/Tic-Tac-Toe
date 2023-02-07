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
            Reset();
            nameP1.Text = Form1.form1Instance.tbx.Text;
        }

        char f1, f2, f3, f4, f5, f6, f7, f8, f9;
        byte clicks;
        bool player = false;

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            labelScoreP1.Text = labelScoreP2.Text = "0";
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Close();
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (Form1.form1Instance.cmb.Text == "Solo")
            {
                switch (pb.Name)
                {
                    case "pB1":
                        f1 = OnClick(f1, pb);
                        break;
                    case "pB2":
                        f2 = OnClick(f2, pb);
                        break;
                    case "pB3":
                        f3 = OnClick(f3, pb);
                        break;
                    case "pB4":
                        f4 = OnClick(f4, pb);
                        break;
                    case "pB5":
                        f5 = OnClick(f5, pb);
                        break;
                    case "pB6":
                        f6 = OnClick(f6, pb);
                        break;
                    case "pB7":
                        f7 = OnClick(f7, pb);
                        break;
                    case "pB8":
                        f8 = OnClick(f8, pb);
                        break;
                    case "pB9":
                        f9 = OnClick(f9, pb);
                        break;
                }
                Win();
            }
            if (Form1.form1Instance.cmb.Text == "Computer")
            {
                switch (pb.Name)
                {
                    case "pB1":
                        f1 = OnClick(f1, pb);
                        ClickKI();                      
                        break;
                    case "pB2":
                        f2 = OnClick(f2, pb);
                        ClickKI();
                        break;
                    case "pB3":
                        f3 = OnClick(f3, pb);
                        ClickKI();
                        break;
                    case "pB4":
                        f4 = OnClick(f4, pb);
                        ClickKI();
                        break;
                    case "pB5":
                        f5 = OnClick(f5, pb);
                        ClickKI();
                        break;
                    case "pB6":
                        f6 = OnClick(f6, pb);
                        ClickKI();
                        break;
                    case "pB7":
                        f7 = OnClick(f7, pb);
                        ClickKI();
                        break;
                    case "pB8":
                        f8 = OnClick(f8, pb);
                        ClickKI();
                        break;
                    case "pB9":
                        f9 = OnClick(f9, pb);
                        ClickKI();
                        break;
                }
                Win();
            }
        }

        char OnClick(char field, PictureBox pB)
        {
            if (field == 'n' && player == false)
            {
                pB.Image = Resources.X;
                pB.Refresh();
                field = 'x';
                clicks++;
                player = true;
            }
            else if (field == 'n' && player)
            {
                pB.Image = Resources.O;
                pB.Refresh();
                field = 'o';
                clicks++;
                player = false;
            }
            return field;
        }
        void ClickKI()
        {
            bool erg = true;
            while (erg)
            {
                if (Random() == 1 && f1 == 'n')
                {
                    pB1.Image = Resources.O;
                    pB1.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 2 && f2 == 'n')
                {
                    pB2.Image = Resources.O;
                    pB2.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 3 && f3 == 'n')
                {
                    pB3.Image = Resources.O;
                    pB3.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 4 && f4 == 'n')
                {
                    pB4.Image = Resources.O;
                    pB4.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 5 && f5 == 'n')
                {
                    pB5.Image = Resources.O;
                    pB5.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 6 && f6 == 'n')
                {
                    pB6.Image = Resources.O;
                    pB6.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 7 && f7 == 'n')
                {
                    pB7.Image = Resources.O;
                    pB7.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 8 && f8 == 'n')
                {
                    pB8.Image = Resources.O;
                    pB8.Refresh();
                    player = false;
                    erg = false;
                }
                else if (Random() == 9 && f9 == 'n')
                {
                    pB9.Image = Resources.O;
                    pB9.Refresh();
                    player = false;
                    erg = false;
                }
                else { erg = true; }
            }
        }

        int Random() 
        { 
            int rnd = new Random().Next(1, 9); 
            return rnd; 
        }
        void Reset()
        {
            pB1.Image = pB2.Image = pB3.Image = pB4.Image = pB5.Image = pB6.Image = pB7.Image = pB8.Image = pB9.Image = Resources.None;
            pB1.Refresh(); pB2.Refresh(); pB3.Refresh(); pB4.Refresh(); pB5.Refresh(); pB6.Refresh(); pB7.Refresh(); pB8.Refresh(); pB9.Refresh();
            f1 = f2 = f3 = f4 = f5 = f6 = f7 = f8 = f9 = 'n';
            clicks = 0;
            player = false;
        }
        bool HasWon(char symbol)
        {
            char[][] winChecks = new char[][]
            {
                new char[] {f1, f2, f3 },
                new char[] {f4, f5, f6 },
                new char[] {f7, f8, f9 },
                new char[] {f1, f5, f9 },
                new char[] {f3, f5, f7 },
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
        void Win()
        {
            if (HasWon('x'))
            {
                labelScoreP1.Text = Convert.ToString(Convert.ToByte(labelScoreP1.Text) + 1);
                MessageBox.Show("Red has won!");
                Reset();
            }
            if (HasWon('o'))
            {
                labelScoreP2.Text = Convert.ToString(Convert.ToByte(labelScoreP2.Text) + 1);
                MessageBox.Show("Blue has won!");
                Reset();
            }
            if (clicks == 9)
            {
                MessageBox.Show("Tie!");
                Reset();
            }
        }
    }
}