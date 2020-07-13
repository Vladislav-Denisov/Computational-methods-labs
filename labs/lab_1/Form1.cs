using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splain
{
    public partial class FormSplain : Form
    {
        const int countPoints = 8; // число точек
        int scale = 17; // масштаб

        Splain splineObj = new Splain();

        public Bitmap btmp; // рисунок
        public Pen axis_pen = new Pen(Color.Black, 1); // для рисования осей
        public Pen spline_pen = new Pen(Color.Blue, 1); // для рисования сплайна
        public SolidBrush points_brush = new SolidBrush(Color.Red); // для рисования опорных точек
        public Pen points_os = new Pen(Color.Black, 1);
        Graphics graph;

        // Массивы для хранения введенных точек. Не отсортированы 
        int[] x = new int[countPoints];
        int[] y = new int[countPoints];

        // Инициализация окна программы
        public FormSplain()
        {
            InitializeComponent();
            DrawAxis();
            pictureBoxSplain.BackgroundImage = btmp;
        }

        // Выбор ручного режима работы
        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            textBoxManual.Enabled = true;
            buttonManual.Enabled = true;
            labelInfoAuto.Visible = false;
            buttonCreateSplain.Enabled = false;
        }

        // Выбор автоматического режима работы
        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            textBoxManual.Enabled = false;
            buttonManual.Enabled = false;
            buttonManualReset.Enabled = false;
            listBoxPoints.Items.Clear();
            labelInfoAuto.Visible = true;
            buttonCreateSplain.Enabled = true;
        }

        // Запрос на вычисление коэффициентов сплайна и его отображение на экран
        private void buttonCreateSplain_Click(object sender, EventArgs e)
        {
            if (radioButtonAuto.Checked == true)
            {
                AutogeneratePoints();
                PrepareSplainData();
                DrawSplain();
            }
            else 
            {
                PrepareSplainData();
                DrawSplain();
            }

            textBoxLog.AppendText("Сплайн успешно построен." + Environment.NewLine);
            trackBarScale.Enabled = true;
        }

        // Подтверждение ввода точки нажатием на кнопку
        private void buttonManual_Click(object sender, EventArgs e)
        {
            ManualInput();
        }

        // Подтверждение ввода точки клавишей Enter
        private void textBoxManual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxManual.SelectAll();
                e.Handled = e.SuppressKeyPress = true;
                ManualInput();
            }
        }

        // Запуск ручного ввода заново
        private void buttonManualReset_Click(object sender, EventArgs e)
        {
            textBoxManual.Enabled = true;
            buttonManual.Enabled = true;
            buttonCreateSplain.Enabled = false;
            buttonManualReset.Enabled = false;
            listBoxPoints.Items.Clear();
            textBoxLog.AppendText("Ручной ввод начат сначала" +
                Environment.NewLine);
        }

        // Масштабирование
        private void trackBarScale_Scroll(object sender, EventArgs e)
        {
            scale = trackBarScale.Value;
            DrawSplain();
        }

        // Проверка на единственное вхождение абсциссы
        public bool IsAbscissaExists(int currentCount, int _x)
        {
            for (int i = 0; i < currentCount; i++)
                if (x[i] == _x)
                    return true;
            return false;
        }

        // Ручной ввод точек
        public void ManualInput()
        {
            string input = textBoxManual.Text;
            int currentCount = listBoxPoints.Items.Count;

            try
            {
                // Проверка на 2 координаты
                int countCh = input.Count(c => c == ';');
                if (countCh != 1)
                    throw new System.Exception("Некорректный ввод\n");

                // Проверка на диапазон и наличие нечисловых символов
                string[] str = input.Split(new char[] { ';' });
                if (Convert.ToInt32(str[0]) > 10 || Convert.ToInt32(str[0]) < -10 ||
                    Convert.ToInt32(str[1]) > 10 || Convert.ToInt32(str[1]) < -10)
                    throw new System.Exception("Неверный диапазон\n");

                // Проверка повторяющихся точек
                if (IsAbscissaExists(currentCount, Convert.ToInt32(str[0]))) 
                {
                    textBoxLog.AppendText("Точка с такой абсциссой (x=" + str[0] + ") уже существует." +
                        " Повторите ввод точки" + Environment.NewLine);
                    return;
                }

                // Добавление точки
                x[currentCount] = Convert.ToInt32(str[0]);
                y[currentCount] = Convert.ToInt32(str[1]);
                listBoxPoints.Items.Insert(currentCount, (currentCount + 1) +
                    ": (" + input + ")");
                textBoxLog.AppendText("Добавлена точка (" +
                    input + ")" + Environment.NewLine);

                // Завершение ввода
                currentCount = listBoxPoints.Items.Count;
                if (currentCount == countPoints)
                {
                    textBoxManual.Enabled = false;
                    buttonManual.Enabled = false;
                    buttonCreateSplain.Enabled = true;
                }
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод новой точки (" +
                    input + ")" + Environment.NewLine);
            }

            buttonManualReset.Enabled = true;
            textBoxManual.Clear();
        }
        
        // Автоматическое создание точек
        public void AutogeneratePoints() 
        {
            listBoxPoints.Items.Clear();
            Random rnd = new Random();
            x[0] = rnd.Next(-10, 10);
            y[0] = rnd.Next(-10, 10);
            string autogenstr = x[0].ToString() + ";" + y[0].ToString();
            listBoxPoints.Items.Insert(0, 1 + ": (" + autogenstr + ")");

            for (int i = 1; i < countPoints; i++)
            {
                do
                    x[i] = rnd.Next(-10, 10);
                while (IsAbscissaExists(i, x[i]));

                y[i] = rnd.Next(-10, 10);

                autogenstr = x[i].ToString() + ";" + y[i].ToString();
                listBoxPoints.Items.Insert(i, (i + 1) + ": (" + autogenstr + ")");
            }

            textBoxLog.AppendText("Точки сгенерированы автоматически." + Environment.NewLine);
        }

        // Передача входных данных на обработку и вычисление коэффициентов
        public void PrepareSplainData() 
        {
            for (int i = 0; i < countPoints; i++)
            {
                splineObj.SetElem(i, 0, x[i]);
                splineObj.SetElem(i, 1, y[i]);
            }

            splineObj.Calculate();
        }

        // Отображение координатных осей
        public void DrawAxis() 
        {
            // Создается bitmap
            btmp = new Bitmap(pictureBoxSplain.Width, pictureBoxSplain.Height);

            pictureBoxSplain.Refresh(); // Очищаем поверхность для рисования
            graph = Graphics.FromImage(btmp); // Инициализируем поверхность для рисования
            graph.TranslateTransform(pictureBoxSplain.Width / 2, pictureBoxSplain.Height / 2); // Перенос начала координат в центр
            graph.ScaleTransform(1, -1); // Смена направления оси OY

            // Координатные оси
            graph.DrawLine(axis_pen, 0, -pictureBoxSplain.Height / 2, 0, pictureBoxSplain.Height / 2);
            graph.DrawLine(axis_pen, -pictureBoxSplain.Width / 2, 0, pictureBoxSplain.Width / 2, 0);

            // Стрелка на оси OY
            graph.DrawLine(axis_pen, 0, pictureBoxSplain.Height / 2 + 1, 5, pictureBoxSplain.Height / 2 - 20);
            graph.DrawLine(axis_pen, 0, pictureBoxSplain.Height / 2 + 1, -5, pictureBoxSplain.Height / 2 - 20);

            // Стрелка на оси OX
            graph.DrawLine(axis_pen, pictureBoxSplain.Width / 2 + 1, 0, pictureBoxSplain.Width / 2 - 20, 5);
            graph.DrawLine(axis_pen, pictureBoxSplain.Width / 2 + 1, 0, pictureBoxSplain.Width / 2 - 20, -5);

            // Отметки на осях
            for (int i = 0; i <= pictureBoxSplain.Width; i += scale)
                graph.DrawLine(points_os, i, -1, i, 1);
            for (int i = 0; i >= -pictureBoxSplain.Width; i -= scale)
                graph.DrawLine(points_os, i, -1, i, 1);

            for (int i = 0; i <= pictureBoxSplain.Height; i += scale)
                graph.DrawLine(points_os, -1, i, 1, i);
            for (int i = 0; i >= -pictureBoxSplain.Height; i -= scale)
                graph.DrawLine(points_os, -1, i, 1, i);

            // 1 на ox
            graph.DrawLine(points_os, scale, -scale / 4 - scale / 2, scale, -scale / 4);
            graph.DrawLine(points_os, scale - scale / 4, -7, scale, -4);

            // 1 на oy
            graph.DrawLine(points_os, scale / 2, scale + scale / 3, scale / 2, scale - scale / 3);
            graph.DrawLine(points_os, scale / 2, scale + scale / 3, scale / 2 - scale / 3, scale + scale / 2 - scale / 3);


            // Начало координат
            graph.DrawLine(points_os, -10, -5, -5, -5);
            graph.DrawLine(points_os, -10, -10, -5, -10);
            graph.DrawLine(points_os, -10, -10, -10, -5);
            graph.DrawLine(points_os, -5, -5, -5, -10);

        }


        public void DrawSplain()
        {
            DrawAxis(); // Отображение координатных осей

            Point[] points = new Point[countPoints];
            for (int i = 0; i < countPoints; i++)
            {
                points[i] = new Point(splineObj.GetElem(i, 0) * scale, splineObj.GetElem(i, 1) * scale);
            }

            graph.DrawCurve(spline_pen, points); // Сплайн

            DrawPoints(null, null); // Опорные точки сплайна

            pictureBoxSplain.BackgroundImage = btmp; // Отображение на экран
        }

        public void DrawPoints(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < countPoints; i++)
                graph.FillRectangle(points_brush, splineObj.GetElem(i, 0) * scale, splineObj.GetElem(i, 1) * scale, 3, 3); // точки рисуются прямоугольниками
        }

    }
}
