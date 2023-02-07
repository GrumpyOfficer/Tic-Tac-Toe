using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public static Form1 form1Instance;
        public TextBox tbx;

        public Form1()
        {
            InitializeComponent();
            form1Instance = this;
            tbx = textBox1;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(textBox1.Text.Length < 1 || textBox1.Text.Length > 7)
            {
                textBox1.BackColor = Color.LightCoral;
            }
            else if (comboBox1.Text.Length < 1)
            {
                comboBox1.BackColor = Color.LightCoral;
            }
            else
            {
                ChangeWindow();
            }
        }
        void ChangeWindow()
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Close();
        }
    }
}
