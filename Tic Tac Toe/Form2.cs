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
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB2":
                        f2 = OnClick(f2, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB3":
                        f3 = OnClick(f3, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB4":
                        f4 = OnClick(f4, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB5":
                        f5 = OnClick(f5, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB6":
                        f6 = OnClick(f6, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB7":
                        f7 = OnClick(f7, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB8":
                        f8 = OnClick(f8, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                    case "pB9":
                        f9 = OnClick(f9, pb);
                        CheckAndSet(ClickKI());
                        Win();
                        break;
                }
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
        int ClickKI()
        {
            List<PictureBox> pbList = new List<PictureBox>() {pB1, pB2, pB3, pB4, pB5, pB6, pB7, pB8, pB9};
            List<char> fList = new List<char>() {f1, f2, f3, f4, f5, f6, f7, f8, f9};
            Random r = new Random();
            
            while (true) 
            {
                int rnd = r.Next(0, 8);
                if (fList[rnd] == 'n')
                {
                    pbList[rnd].Image = Resources.O;
                    pbList[rnd].Refresh();
                    player = false;
                    clicks++;
                    return rnd;
                }
            }
        }
        void CheckAndSet(int p)
        {
            if (p == 0) { f1 = 'o'; }
            if (p == 1) { f2 = 'o'; }
            if (p == 2) { f3 = 'o'; }
            if (p == 3) { f4 = 'o'; }
            if (p == 4) { f5 = 'o'; }
            if (p == 5) { f6 = 'o'; }
            if (p == 6) { f7 = 'o'; }
            if (p == 7) { f8 = 'o'; }
            if (p == 8) { f9 = 'o'; }
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
        bool WinCheck(char symbol)
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
            if (WinCheck('x'))
            {
                labelScoreP1.Text = Convert.ToString(Convert.ToByte(labelScoreP1.Text) + 1);
                MessageBox.Show("Red has won!");
                Reset();
            }
            if (WinCheck('o'))
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