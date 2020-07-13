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

namespace Initial_boundary_problem_for_INT_DIF_part_equ
{
    public partial class Form1 : Form
    {
        Thermal thermal = new Thermal();
        bool hasSolution = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Stopwatch StWatch = new System.Diagnostics.Stopwatch();
                textBoxLog.AppendText("Для нахождения решения будут использованы параметры: " +
                   Environment.NewLine + "- Длина стержня l = " + thermal.L + " и время воздействия T = " + thermal.T +
                   Environment.NewLine + "- Шаг по пространству h = " + thermal.h + " и шаг по времени tau = " +
                                            thermal.tau +
                   Environment.NewLine + "- Коэффициенты управляющей функции: b0 = " +
                                            thermal.b0 + ", b1 = " + thermal.b1 + ", b2 = " + thermal.b2 +
                   Environment.NewLine + "- Коэффициенты начальной функции: phi1 = " +
                                            thermal.phi1 + ", phi2 = " + thermal.phi2 +
                   Environment.NewLine);
                StWatch.Start();

                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
                chart.Series[2].Points.Clear();

                hasSolution = false;

                progressBar.Value = 0;
                thermal.Algorithm(ref progressBar);

                hasSolution = true;

                chart.ChartAreas[0].AxisX.Minimum = 0;
                chart.ChartAreas[0].AxisX.Maximum = thermal.L;

                for (int i = 0; i < thermal.LCount; i++)
                {
                    chart.Series[0].Points.AddXY(i * thermal.h, thermal.phi[i]);
                    chart.Series[1].Points.AddXY(i * thermal.h, thermal.grid[i, thermal.TCount - 1]);
                    if (checkBoxGraphA.Checked)
                    {
                        chart.Series[2].Points.AddXY(i * thermal.h, thermal.grid_part_a[i, thermal.TCount - 1]);
                    }
                }

                StWatch.Stop();
                long ms = StWatch.ElapsedMilliseconds;
                labelTime.Text = Convert.ToString(ms / 1000) + " s " + Convert.ToString(ms % 1000) + " ms";
            }
            catch
            {
                textBoxLog.AppendText("Во время выполнения что-то пошло не так. Повторите попытку." + 
                    Environment.NewLine);
            }
        }

        private void textBoxInputL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputL();
            }
        }
        public void InputL()
        {
            string input = textBoxInputL.Text;
            try
            {
                thermal.L = Convert.ToDouble(input);
                if (thermal.L <= 0)
                    throw new System.Exception("Некорректный ввод значения длины стержня\n");
                textBoxInputT.Focus();
                textBoxLog.AppendText("Выбрана длина стержня: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения длины стержня: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputT();
            }
        }
        public void InputT()
        {
            string input = textBoxInputT.Text;
            try
            {
                thermal.T = Convert.ToDouble(input);
                if (thermal.T <= 0)
                    throw new System.Exception("Некорректный ввод значения времени\n");
                textBoxInputH.Focus();
                textBoxLog.AppendText("Выбрано время: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения времени: " +
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
                thermal.h = Convert.ToDouble(input);
                if (thermal.h <= 0)
                    throw new System.Exception("Некорректный ввод значения шага (по координате x)\n");
                textBoxInputTau.Focus();
                textBoxLog.AppendText("Выбрано значение шага (по координате x): " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения шага (по координате x): " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputTau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputTau();
            }
        }

        public void InputTau()
        {
            string input = textBoxInputTau.Text;
            try
            {
                thermal.tau = Convert.ToDouble(input);
                if (thermal.tau <= 0)
                    throw new System.Exception("Некорректный ввод значения шага (по координате t)\n");
                textBoxInputB0.Focus();
                textBoxLog.AppendText("Выбрано значение шага (по координате t): " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения шага (по координате t): " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputB0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputB0();
            }
        }

        public void InputB0()
        {
            string input = textBoxInputB0.Text;
            try
            {
                thermal.b0 = Convert.ToDouble(input);
                textBoxInputB1.Focus();
                textBoxLog.AppendText("Выбрано значение параметра b0: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения параметра b0: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputB1();
            }
        }

        public void InputB1()
        {
            string input = textBoxInputB1.Text;
            try
            {
                thermal.b1 = Convert.ToDouble(input);
                textBoxInputB2.Focus();
                textBoxLog.AppendText("Выбрано значение параметра b1: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения параметра b1: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputB2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputB2();
            }
        }

        public void InputB2()
        {
            string input = textBoxInputB2.Text;
            try
            {
                thermal.b2 = Convert.ToDouble(input);
                textBoxInputPhi1.Focus();
                textBoxLog.AppendText("Выбрано значение параметра b2: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения параметра b2: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputPhi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputPhi1();
            }
        }
        public void InputPhi1()
        {
            string input = textBoxInputPhi1.Text;
            try
            {
                thermal.phi1 = Convert.ToDouble(input);
                textBoxInputPhi2.Focus();
                textBoxLog.AppendText("Выбрано значение параметра phi1: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения параметра phi1: " +
                    input + Environment.NewLine);
            }
        }

        private void textBoxInputPhi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    InputPhi2();
            }
        }
        public void InputPhi2()
        {
            string input = textBoxInputPhi2.Text;
            try
            {
                thermal.phi2 = Convert.ToDouble(input);
                buttonSolve.Focus();
                textBoxLog.AppendText("Выбрано значение параметра phi2: " +
                    input + Environment.NewLine);
            }
            catch
            {
                textBoxLog.AppendText("Некорректный ввод значения параметра phi2: " +
                    input + Environment.NewLine);
            }
        }

        private void checkBoxGraphA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGraphA.Checked && hasSolution)
            {
                for (int i = 0; i < thermal.LCount; i++)
                {
                    chart.Series[2].Points.AddXY(i * thermal.h, thermal.grid_part_a[i, thermal.TCount - 1]);
                }
            }
            else if (!checkBoxGraphA.Checked)
            {
                chart.Series[2].Points.Clear();
            }

        }
    }
}
