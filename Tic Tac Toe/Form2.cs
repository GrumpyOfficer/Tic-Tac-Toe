using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Tic_Tac_Toe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); 
            Reset();
            nameP1.Text = Form1.form1Instance.tbx.Text;
            ClickKI();
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
            List<PictureBox> pbList = new List<PictureBox>() {pB1, pB2, pB3, pB4, pB5, pB6, pB7, pB8, pB9};
            List<char> fList = new List<char>() {f1, f2, f3, f4, f5, f6, f7, f8, f9};

            bool check = false;
            while(check == false)
            {
                int rnd = random();
                if (fList[rnd] == 'n')
                {
                    fList[rnd] = 'o';
                    pbList[rnd].Image = Resources.O;
                    check = true;
                    player = false; 
                }
            }
            f1 = fList[0];
            f2 = fList[1];
            f3 = fList[2];
            f4 = fList[3];
            f5 = fList[4];
            f6 = fList[5];
            f7 = fList[6];
            f8 = fList[7];
            f9 = fList[8];
        }

        int random()
        {
            Random r = new Random();
            int rnd = r.Next(0, 8);
            return rnd;
        }
        void Reset()
        {
            List<PictureBox> pbList = new List<PictureBox>() { pB1, pB2, pB3, pB4, pB5, pB6, pB7, pB8, pB9 };
            for(int i = 0; i < pbList.Count; i++)
            {
                pbList[i].Image = Resources.None;
                pbList[i].Refresh();
            }
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
                Console.WriteLine("red has won");
                Reset();
            }
            if (HasWon('o'))
            {
                labelScoreP2.Text = Convert.ToString(Convert.ToByte(labelScoreP2.Text) + 1);
                MessageBox.Show("Blue has won!");
                Console.WriteLine("blue has won");
                Reset();
            }
            if (clicks == 9)
            {
                MessageBox.Show("Tie!");
                Console.WriteLine("tie");
                Reset();
            }
        }
    }
}