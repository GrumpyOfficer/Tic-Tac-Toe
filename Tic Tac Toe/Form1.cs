using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(textBox1.Text.Length < 1)
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
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
