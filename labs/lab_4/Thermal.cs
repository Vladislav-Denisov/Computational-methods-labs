using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Initial_boundary_problem_for_INT_DIF_part_equ
{
    class Thermal
    {
        public double[,] grid;  // сетка для нахождения решения
        public double[,] grid_part_a;  // сетка для нахождения решения части А
        public double[] b;  // значения функции b для каждого слоя
        public double[] phi;  // значения фукнции фи для каждого слоя
        public double phi1, phi2;  // коэффициенты для функции phi
        public double b0, b1, b2;  // коэффициенты для функции b
        public double T;  // время воздействия
        public double L;  // длина стержня
        public double tau;  // величина шага по времени tau
        public double h;  // величина шага по длине стержня х
        public double coeff = 1.0;  // a в уравнении (1) в методичке
        public int TCount;  // число шагов по времени tau
        public int LCount;  // число шагов по длине стержня х

        // Функция phi(x) - начальное распределение температуры
        public double function_phi(double x)
        {
            return 1.0 / L + phi1 * Math.Cos(Math.PI * x / L) + phi2 * Math.Cos(2.0 * Math.PI * x / L);
        }

        // Функция b(x) - управляющая функция
        public double function_b(double x)
        {
            return b0 + b1 * Math.Cos(Math.PI * x / L) + b2 * Math.Cos(2.0 * Math.PI * x / L);
        }

        // Метод Симпсона для вычисления интеграла в части Б
        public double SimpsonMethod(int j)
        {
            double value = b[0] * grid[0, j];

            for (int i = 1; i < LCount - 1; i++)
            {
                if (i % 2 == 0)
                    value += 2.0 * b[i + 1] * grid[i + 1, j];
                else
                    value += 4.0 * b[i] * grid[i, j];
            }

            value += b[LCount - 1] * grid[LCount - 1, j];
            value = value * h / 3.0;

            return value;
        }

        // Метод Симпсона для вычисления интеграла в части А
        public double SimpsonMethod_W(double[,] w, int j)
        {
            double value = w[0, j];

            for (int i = 1; i < LCount - 1; i++)
            {
                if (i % 2 == 0)
                    value += 2.0 * w[i + 1, j];
                else
                    value += 4.0 * w[i, j];
            }

            value += w[LCount - 1, j];
            value = value * h / 3.0;

            return value;
        }

        // Метод прогонки для 3-х диагональной матрицы
        public double[] TridiagonalMatrixAlgorithm(double A, double B, double C, double AL, double C0, double[] F)
        {
            double[] y = new double[LCount];
            double[] alpha = new double[LCount];
            double[] beta = new double[LCount];

            alpha[0] = -1.0 * C0 / B;
            beta[0] = F[0] / B;

            for (int i = 1; i < LCount - 1; i++)
            {
                alpha[i] = -1.0 * C / (A * alpha[i - 1] + B);
                beta[i] = (F[i] - A * beta[i - 1]) / (A * alpha[i - 1] + B);
            }

            y[LCount - 1] = (F[LCount - 1] - AL * beta[LCount - 2]) / (AL * alpha[LCount - 2] + B);

            for (int i = LCount - 2; i >= 0; i--)
                y[i] = alpha[i] * y[i + 1] + beta[i];

            return y;
        }

        // Основной алгоритм решения задачи, включающий вызов вспомогательных функций в требуемом порядке
        public void Algorithm(ref ProgressBar progressBar)
        {
            TCount = Convert.ToInt32(T / tau) + 1;
            LCount = Convert.ToInt32(L / h) + 1;

            progressBar.Minimum = 0;
            progressBar.Maximum = 2 * LCount + (TCount) * (2 * LCount);
            progressBar.Step = 1; 

            grid = new double[LCount, TCount];
            grid_part_a = new double[LCount, TCount];
            b = new double[LCount];
            phi = new double[LCount];

            // Инициализация необходимых переменных
            double[] y;
            double[] y_part_a;
            double[] F = new double[LCount];
            double[] F_part_a = new double[LCount];

            // Первоначальная инициализация функций по интервалам сетки
            for (int i = 0; i < LCount; i++)
            {
                phi[i] = function_phi(i * h);
                b[i] = function_b(i * h);
                grid[i, 0] = phi[i];
                grid_part_a[i, 0] = phi[i];
                
                progressBar.PerformStep();
            }

            // Инициализация коэффициентов для метода прогонки
            double r = coeff * coeff * tau / (h * h);  // Выполняем замену для удобства
            double A = r;
            double B = -1.0 - 2.0 * r;
            double C = r;
            double AL = 2.0 * r;
            double C0 = 2.0 * r;

            // Решение задачи
            for (int j = 0; j < TCount - 1; j++)
            {
                double integral = SimpsonMethod(j);
                for (int i = 0; i < LCount; i++)
                {
                    F[i] = -1.0 * grid[i, j] * (1.0 + tau * b[i] - tau * integral);
                    F_part_a[i] = -1.0 * grid_part_a[i, j] * (1.0 + tau * b[i]);

                    progressBar.PerformStep();
                }

                y = TridiagonalMatrixAlgorithm(A, B, C, AL, C0, F);
                y_part_a = TridiagonalMatrixAlgorithm(A, B, C, AL, C0, F_part_a);

                for (int i = 0; i < LCount; i++)
                {
                    grid[i, j + 1] = y[i];
                    grid_part_a[i, j + 1] = y_part_a[i];

                    progressBar.PerformStep();
                }
            }

            // Нахождения решения при помощи части А
            double square = SimpsonMethod_W(grid_part_a, TCount - 1);
            for (int i = 0; i < LCount; i++)
            {
                grid_part_a[i, TCount - 1] = grid_part_a[i, TCount - 1] / square;

                progressBar.PerformStep();
            }

            progressBar.Value = progressBar.Maximum;
        }  // function Algorithm
    }  // Class Thermal
}
