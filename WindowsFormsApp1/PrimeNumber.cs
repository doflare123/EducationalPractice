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
    public partial class PrimeNumber : Form
    {
        Form1 form1 = new Form1();
        int dotCount = 0;
        string animationText;
        private Random random;
        private List<string> phrases;
        private MainMenu mainMenu = new MainMenu();
        private int clickButton = 0;
        private bool checkPerfect(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public PrimeNumber()
        {
            InitializeComponent();
            phrases = mainMenu.phrases;
            random = new Random();
        }

        private void PrimeNumber_Load(object sender, EventArgs e)
        {

        }

        int intNum1 = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string clearTxt = textBox1.Text.Replace(" ", "");
            bool realNum = int.TryParse(clearTxt, out intNum1);

            if (realNum && clearTxt != "" && intNum1 >= 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            loading.Text = animationText + new string('.', dotCount);
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            clickButton++;
            if(clickButton > 2)
            {
                clickButton = 1;
            }
            int localId = clickButton;
            perfectsBox.Text = "";
            int cnum = 1;
            int count = 0;
            animationText = phrases[random.Next(phrases.Count)];
            loading.Text = animationText;
            loading.Show();
            animationTimer.Start();
            while (count < intNum1 && clickButton == localId)
            {
                if (checkPerfect(cnum))
                {
                    if (perfectsBox.Text != "")
                    {
                        perfectsBox.Text += ", ";
                    }
                    perfectsBox.Text += cnum;
                }
                cnum++;
                count++;

                await Task.Delay(10);
            }
            if (clickButton == localId)
            {
                animationTimer.Stop();
                loading.Hide();
            }
        }
    }
}
