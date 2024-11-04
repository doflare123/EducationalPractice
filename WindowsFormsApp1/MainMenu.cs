using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            label1.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            label1.ForeColor = Color.Gray;
            label2.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            label2.ForeColor = Color.Gray;
            label3.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            label3.ForeColor = Color.Gray;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
