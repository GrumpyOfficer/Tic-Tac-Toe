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
            bool error=false;
            if(textBox1.Text.Length < 1)
            {
                textBox1.BackColor = Color.LightCoral;
                MessageBox.Show("To short!");
                error=false;
            }
            if (textBox1.Text.Length > 7)
            {
                MessageBox.Show("To long!");
                error=false;
            }
            if (comboBox1.Text.Length < 1)
            {
                comboBox1.BackColor = Color.LightCoral;
                MessageBox.Show("Select opponent!");
                error=false;
            }
            if(error)
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
