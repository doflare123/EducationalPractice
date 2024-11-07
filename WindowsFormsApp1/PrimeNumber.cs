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
        // Объявление переменных
        int dotCount = 0; // Количество точек для анимации
        string animationText; // Текст для анимации
        private Random random;
        private List<string> phrases; // Список фраз для загрузки
        private MainMenu mainMenu = new MainMenu(); // Ссылка на главную форму
        private int clickButton = 0; // ID текущего поиска простых чисел
        private bool checkPerfect(int num) // Проверка является ли num простым числом
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
        public PrimeNumber() // Инициализация формы
        {
            InitializeComponent();
            phrases = mainMenu.phrases;
            random = new Random();
        }

        int intNum1 = 0; // Искомое количество простых чисел
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string clearTxt = textBox1.Text.Replace(" ", ""); // Текст без пробелов
            bool realNum = int.TryParse(clearTxt, out intNum1); // проверка является ли текст числом

            if (realNum && clearTxt != "" && intNum1 >= 0)
            {
                button1.Enabled = true; // Включения кнопки поиска
            }
            else
            {
                button1.Enabled = false; // Выключения кнопки поиска
            }
        }

        private void button2_Click(object sender, EventArgs e) // Закрытие этой формы
        {
            this.Close();
            mainMenu.Show();
        }

        private void animationTimer_Tick(object sender, EventArgs e) // Анимация загрузки
        {
            dotCount = (dotCount + 1) % 4;
            loading.Text = animationText + new string('.', dotCount);
        }

        private async void button1_Click_1(object sender, EventArgs e) // Кнопка поиска
        {
            clickButton++; // Обновления айди текущего поиска
            if (clickButton > 2)
            {
                clickButton = 1;
            }
            int localId = clickButton; // локальное айди
            perfectsBox.Text = "";
            int cnum = 1; // текущее проверяемое число
            int count = 0; // количество простых чисел
            animationText = phrases[random.Next(phrases.Count)]; // случайная фраза для загрузки
            loading.Text = animationText;
            loading.Show();
            animationTimer.Start(); // начало анимации загрузки
            while (count < intNum1 && clickButton == localId)
            {
                if (checkPerfect(cnum)) // оформление текста
                {
                    if (perfectsBox.Text != "")
                    {
                        perfectsBox.Text += ", ";
                    }
                    perfectsBox.Text += cnum;
                }
                cnum++;
                count++;

                await Task.Delay(10); // задержка для того чтобы красиво показывались простые числа
            }
            if (clickButton == localId)
            {
                animationTimer.Stop(); // Остановка анимации
                loading.Hide();
            }
        }
    }
}
