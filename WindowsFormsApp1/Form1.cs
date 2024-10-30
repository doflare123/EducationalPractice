﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Timer animationTimer;
        private string animationText;
        private int dotCount = 0;
        private List<string> phrases;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            Bibidzan.Hide();
            labelStatus.Hide();

            // Инициализация списка фраз
            phrases = new List<string>
            {
                "Завариваем чай",
                "Пытаемся вычислить",
                "Находим простые числа",
                "Запускаем процесс",
                "Медитируем над числами",
                "Считаем звезды",
                "Ожидаем чудо",
                "Сканируем пространство",
                "Проверяем данные",
                "Готовим результаты"
            };

            random = new Random();

            // Настройка таймера для анимации
            animationTimer = new Timer();
            animationTimer.Interval = 500; // Полсекунды между обновлениями
            animationTimer.Tick += AnimationTimer_Tick;

            button1.Text = "Начать расчет";
            button1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            button1.BackColor = Color.CornflowerBlue;
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;

            textBox1.Font = new Font("Segoe UI", 12);
            richTextBox1.Font = new Font("Segoe UI", 10);
            richTextBox1.BackColor = Color.WhiteSmoke;

            labelStatus.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            labelStatus.ForeColor = Color.Gray;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            long diapos;
            bool isParsed = long.TryParse(textBox1.Text, out diapos);

            if (isParsed && diapos >= 2)
            {
                richTextBox1.Clear();
                Bibidzan.Show();

                // Выбираем случайную фразу и запускаем анимацию
                animationText = phrases[random.Next(phrases.Count)];
                labelStatus.Text = animationText;
                labelStatus.Show();
                animationTimer.Start();

                // Основные вычисления
                bool[] isPrime = new bool[diapos + 1];
                for (int i = 2; i <= diapos; i++) isPrime[i] = true;

                for (int i = 2; i * i <= diapos; i++)
                {
                    if (isPrime[i])
                    {
                        for (int j = i * i; j <= diapos; j += i)
                        {
                            isPrime[j] = false;
                        }
                    }
                }

                int maxCharsPerLine = 50;
                string line = "";

                for (int i = 2; i <= diapos; i++)
                {
                    if (isPrime[i])
                    {
                        string nextNumber = i.ToString();

                        if (line.Length + nextNumber.Length + 1 > maxCharsPerLine)
                        {
                            richTextBox1.AppendText(line + Environment.NewLine);
                            line = "";
                        }

                        line += (line == "" ? "" : ", ") + nextNumber;

                        await Task.Delay(100);
                    }
                }

                if (line != "")
                {
                    richTextBox1.AppendText(line + Environment.NewLine);
                }

                // Останавливаем анимацию и скрываем элементы
                animationTimer.Stop();
                labelStatus.Hide();
                Bibidzan.Hide();
            }
            else
            {
                MessageBox.Show("Введите корректное число больше или равное 2.");
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            labelStatus.Text = animationText + new string('.', dotCount);
        }
    }
}
