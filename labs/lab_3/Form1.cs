using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cauchy_problem_ODE
{
    public partial class Form1 : Form
    {
        double intervalA;  // Интервал интегрирования
        double intervalB;  // Интервал интегрирования
        double eps;  // локальная погрешность
        double h;  // величина шага 
        int numberSteps;  // число шагов интегрирования

        double sigma;  // параметр ДУ

        double x0;  // начальное значение x0
        double v0;  // начальное значение v0

        int numSpline = 0;  // текущее число фазовых траекторий

        public Form1()
        {
            InitializeComponent();
        }

        // Делаем замену x' = v
        private double func(double x, double v)
        {
            return -1 * (sigma * v + Math.Sin(x));
        }

        // Метод Рунге-Кутта 4-го порядка
        private void RungeCutte() 
        {
            numSpline++;
            string nameSeries = numSpline.ToString();
            chart.Series.Add(nameSeries);
            chart.Series[nameSeries].Color = Color.Blue;
            chart.Series[nameSeries].ChartType = SeriesChartType.Spline;

            numberSteps = (int)((intervalB - intervalA) / h);
            double x = x0;
            double v = v0;

            chart.Series[nameSeries].Points.AddXY(x, v);

            double localH = h;
            for (int i = 0; i <= numberSteps; ++i)
            {
                double[] oneStepWithH = calcOnOneStepWithH(x, v, localH);
                double[] twoStepWithHdiv2 = calcOnTwoStepWithH(x, v, localH / 2);

                double localEpsControlValue = (twoStepWithHdiv2[0] - oneStepWithH[0]) / 15;

                if (System.Math.Abs(localEpsControlValue) > eps)
                {
                    localH = localH / 2;
                    while (System.Math.Abs(localEpsControlValue) > eps) 
                    {
                        oneStepWithH = calcOnOneStepWithH(x, v, localH);
                        twoStepWithHdiv2 = calcOnTwoStepWithH(x, v, localH / 2);
                        localEpsControlValue = (twoStepWithHdiv2[0] - oneStepWithH[0]) / 15;
                    }
                }
                else if (System.Math.Abs(localEpsControlValue) < eps / 32)
                {
                    localH = 2 * localH;
                }
                x = oneStepWithH[0];
                v = oneStepWithH[1];
                chart.Series[nameSeries].Points.AddXY(x, v);
                numberSteps = (int)((intervalB - intervalA) / localH);
            }
        }

        // Один шаг метода Р-К с величиной _h
        private double[] calcOnOneStepWithH(double _x, double _v, double _h) 
        {
            double[] result = new double[2];

            double k1, k2, k3, k4;
            double l1, l2, l3, l4;

            k1 = _v;
            l1 = func(_x, _v);

            k2 = _v + (_h / 2) * l1;
            l2 = func(_x + (_h / 2) * k1, _v + (_h / 2) * l1);

            k3 = _v + (h / 2) * l2;
            l3 = func(_x + (_h / 2) * k2, _v + (_h / 2) * l2);

            k4 = _v + _h * l3;
            l4 = func(_x + _h * k3, _v + _h * l3);

            result[0] = _x + _h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
            result[1] = _v + _h / 6 * (l1 + 2 * l2 + 2 * l3 + l4);

            return result;
        }

        // Два шага метода Р-К с величиной h/2
        private double[] calcOnTwoStepWithH(double _x, double _v, double _h)
        {
            double[] result = new double[2];
            result = calcOnOneStepWithH(_x, _v, _h);
            result = calcOnOneStepWithH(result[0], result[1], _h);
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLog.AppendText("Программа успешно запущена!" + Environment.NewLine);
            chart.ChartAreas[0].AxisX.Minimum = -20;
            chart.ChartAreas[0].AxisX.Maximum = 20;
            chart.ChartAreas[0].AxisY.Minimum = -20;
            chart.ChartAreas[0].AxisY.Maximum = 20;
        }

        private void buttonManualReset_Click(object sender, EventArgs e)
        {
            chart.Series.Clear();

            numSpline = 0;
            intervalA = intervalB = 0;
            eps = 0;
            h = 0;
            numberSteps = 0;
            sigma = 0;
            x0 = v0 = 0;

            textBoxInputAB.Clear();
            textBoxInputEPS.Clear();
            textBoxInputH.Clear();
            textBoxInputSigma.Clear();
            textBoxInputXZero.Clear();
            textBoxInputVZero.Clear();

            textBoxInputAB.Enabled = true;
            textBoxInputSigma.Enabled = true;

            textBoxLog.AppendText("Параметры для построения фазовой траектории сброшены. График очищен." +
                    Environment.NewLine);
        }

        private void textBoxInputAB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputAB();
            }
        }
        public void InputAB()
        {
            string input = textBoxInputAB.Text;

            try
            {
                // Проверка на 2 числа во вводе
                int countCh = input.Count(c => c == ';');
                if (countCh != 1)
                    throw new System.Exception("Некорректный ввод границ интегрирования\n");

                // Добавление границ
                string[] str = input.Split(new char[] { ';' });
                intervalA = Convert.ToDouble(str[0]);
                intervalB = Convert.ToDouble(str[1]);
                if (intervalA >= intervalB) 
                {
                    intervalA = intervalB = 0;
                    throw new System.Exception("Некорректный ввод границ интегрирования\n");
                }
                textBoxLog.AppendText("Установлены границы интегрирования (" +
                    input + ")" + Environment.NewLine);

                // Завершение ввода
                textBoxInputAB.Enabled = false;
                textBoxInputEPS.Focus();
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод границ интегрирования (" +
                    input + ")" + Environment.NewLine);
            }
        }

        private void textBoxEPS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputEPS();
            }
        }
        public void InputEPS()
        {
            string input = textBoxInputEPS.Text;
            try
            {
                eps = Convert.ToDouble(input);
                if (eps <= 0)
                    throw new System.Exception("Некорректный ввод значения локальной погрешности\n");
                textBoxInputH.Focus();
                textBoxLog.AppendText("Выбрана локальная погрешность: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения локальной погрешности: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputH();
            }
        }

        public void InputH()
        {
            string input = textBoxInputH.Text;
            try
            {
                h = Convert.ToDouble(input);
                if (h <= 0)
                    throw new System.Exception("Некорректный ввод значения начального шага интегрирования");
                if (textBoxInputSigma.Enabled == true)
                    textBoxInputSigma.Focus();
                else 
                    textBoxInputXZero.Focus();
                textBoxLog.AppendText("Выбран начальный шаг интегрирования: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения начального шага интегрирования: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputSigma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputSigma();
            }
        }

        public void InputSigma()
        {
            string input = textBoxInputSigma.Text;
            try
            {
                sigma = Convert.ToDouble(input);
                textBoxLog.AppendText("Выбрано значение sigma: " +
                    input + Environment.NewLine);
                textBoxInputXZero.Focus();
                textBoxInputSigma.Enabled = false;
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения sigma: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputXZero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputXZero();
            }
        }

        public void InputXZero()
        {
            string input = textBoxInputXZero.Text;
            try
            {
                x0 = Convert.ToDouble(input);
                textBoxInputVZero.Focus();
                textBoxLog.AppendText("Выбрано значение x0: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения x0: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputVZero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputVZero();
            }
        }

        public void InputVZero()
        {
            string input = textBoxInputVZero.Text;
            try
            {
                v0 = Convert.ToDouble(input);
                buttonSolve.Focus();
                textBoxLog.AppendText("Выбрано значение v0: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения v0: " +
                    input + Environment.NewLine);
            }
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxLog.AppendText("Для построения фазовой траектории использованы параметры: " +
                    Environment.NewLine + "- Интервал интегрирования [" + intervalA + "; " + intervalB + "]" +
                    ", шаг (начальное значение) h = " + h + "," +
                    Environment.NewLine + "- Локальная погрешность eps = " + eps +
                    Environment.NewLine + "- Параметр ДУ sigma = " + sigma +
                    " и начальные условия x0 = " + x0 + "; v0 = " + v0 +
                    Environment.NewLine); ;
                RungeCutte();
            }
            catch 
            {
                textBoxLog.AppendText("Упс! Что-то пошло не так. Проверьте входные параметры и повторите попытку" +
                    Environment.NewLine);
            }
            
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            v0 = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
            textBoxInputXZero.Text = x0.ToString();
            textBoxInputVZero.Text = v0.ToString();
        }
    }
}
