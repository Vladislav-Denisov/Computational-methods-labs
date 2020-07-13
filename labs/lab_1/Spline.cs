using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splain
{
    class Splain
    {
        const int countPoints = 8; // количество точек

        // массив точек, по которым строится сплайн
        int[,] mas = new int[countPoints, 2];

        // Массивы коэффициентов ai, bi, ci, di.
        double[] a = new double[countPoints];
        double[] b = new double[countPoints];
        double[] c = new double[countPoints + 1]; // больше на 1, т.к. по формуле так
        double[] d = new double[countPoints];

        // Изменение xi или yi (pos = 0 - x, pos = 1 - y)
        public void SetElem(int num, int pos, int elem)
        {
            mas[num, pos] = elem;
        }

        // Получение xi или yi (pos = 0 - x, pos = 1 - y)
        public int GetElem(int num, int pos)
        {
            return mas[num, pos];
        }

        // Получение коэффициента ai
        public double GetA(int num)
        {
            return a[num];
        }

        // Получение коэффициента bi
        public double GetB(int num)
        {
            return b[num];
        }

        // Получение коэффициента ci
        public double GetC(int num)
        {
            return c[num];
        }

        // Получение коэффициента di
        public double GetD(int num)
        {
            return d[num];
        }

        // Обмен значений
        public void Swap(ref int first, ref int last) 
        {
            int tmp = first;
            first = last;
            last = tmp;
        }

        // Быстрая сортировка
        public void QuickSort(int _first, int _last)
        {
            int first = _first, last = _last;
            int mid = mas[(first + last) / 2, 0];

            do
            {
                while (mas[first, 0] < mid)
                    first++;
                while (mas[last, 0] > mid)
                    last--;

                if (first <= last)
                {
                    Swap(ref mas[first, 0], ref mas[last, 0]);
                    Swap(ref mas[first, 1], ref mas[last, 1]);
                    first++;
                    last--;
                }
            } while (first < last);

            if (_first < last)
                QuickSort(_first, last);
            if (first < _last)
                QuickSort(first, _last);
        }

        // Решение СЛАУ методом прогонки
        public void TridiagonalMatrixAlgorithm(double[] h, double[] _с)
        {
            // Выделение памяти под 3-х диагональную матрицу
            // (3 строки: 
            // если добавить индекс строки к i -> получим нужное слагаемое)
            // (см. формулу ниже)
            double[,] matrA = new double[countPoints - 1, 3];

            // Заполнение матрицы, из которой будут найдены ci
            // Используется формула:
            // H(i+1) * C(i+2) + (2 * H(i+1) + 2 * Hi) * C(i+1) + Hi * Ci

            // Настоящий индекс Ci, который согласуется с лекциями = C(i+1)
            // т.е. C[1] в программе = C[2] в лекциях.

            // Особый случай:
            // Начало с i = 2 в лекциях
            // Первая строка матрицы, из которой будет найдено решение
            matrA[1, 0] = 0;
            matrA[1, 1] = 2 * h[2] + 2 * h[1];
            matrA[1, 2] = h[2];

            // Заполнение всех строк
            // с i = 3 до i = n-2 в лекциях
            for (int i = 2; i < (countPoints - 2); i++)
            {
                matrA[i, 0] = h[i];
                matrA[i, 1] = (2 * h[i + 1] + 2 * h[i]);
                matrA[i, 2] = h[i + 1];
            }

            // Особый случай:
            // Конец i = n-1 в лекциях
            // Последняя строка матрицы, из которой будет найдено решение
            matrA[countPoints - 2, 0] = h[countPoints - 2];
            matrA[countPoints - 2, 1] = 2 * h[countPoints - 1] + 2 * h[countPoints - 2];
            matrA[countPoints - 2, 2] = 0;

            // Выделение памяти для вектора правой части СЛАУ
            double[] vectorB = new double[countPoints - 1];
            double first_summand, second_summand; // рабочие переменные

            // Нахождение значений вектора правой части СЛАУ
            // используем mas[, 1] = y[]
            for (int i = 1; i < countPoints - 1; i++)
            {
                first_summand = (mas[i + 1, 1] - mas[i, 1]) / h[i + 1];
                second_summand = (mas[i, 1] - mas[i - 1, 1]) / h[i];
                vectorB[i] = 3 * (first_summand - second_summand);
            }

            // Метод прогонки
            int N1 = countPoints - 2;
            double y;
            double[] A = new double[countPoints - 1];
            double[] B = new double[countPoints - 1];
            double[] prom_res = new double[countPoints - 1];
            y = matrA[1, 1];
            A[1] = -matrA[1, 2] / y;
            B[1] = vectorB[1] / y;
            for (int i = 2; i < N1; i++)
            {
                y = matrA[i, 1] + matrA[i, 0] * A[i - 1];
                A[i] = -matrA[i, 2] / y;
                B[i] = (vectorB[i] - matrA[i, 0] * B[i - 1]) / y;
            }

            // Вычисление результата
            prom_res[N1] = (vectorB[N1] - matrA[N1, 0] * B[N1 - 1]) / 
                           (matrA[N1, 1] + matrA[N1, 0] * A[N1 - 1]);
            for (int i = N1 - 1; i >= 1; i--)
            {
                prom_res[i] = A[i] * prom_res[i + 1] + B[i];
            }

            // Приведение ответа к корректным индексам
            for (int i = 1; i < countPoints - 1; i++)
            {
                _с[i + 1] = prom_res[i];
            }
        }

        public void Calculate()
        {
            // К элементу с индексом [0] не будет обращений.
            // Разница ("дельта") между xi и x(i-1)
            double[] h = new double[countPoints]; 

            // Первичная инициализация искомых коэффициентов
            for (int i = 0; i < countPoints; i++)
            {
                h[i] = a[i] = b[i] = d[i] = 0;
                c[i] = 1;
            }
            // Особые случаи
            c[countPoints] = 0;
            c[1] = 0;

            // Сортировка точек по возрастанию
            QuickSort(0, countPoints - 1);
            
            // Вычисление разницы ("дельты")
            for (int i = 1; i < countPoints; i++)
                h[i] = mas[i, 0] - mas[i - 1, 0];

            // Нахождение коэффициентов ci методом прогонки
            TridiagonalMatrixAlgorithm(h, c);

            //Нахождение коэффициентов a, d, b
            for (int i = 1; i < countPoints; i++)
            {
                a[i] = mas[i - 1, 1];
                d[i] = (c[i + 1] - c[i]) / (3 * h[i]);
                b[i] = (mas[i, 1] - mas[i - 1, 1]) / h[i] - c[i] * h[i] - (c[i + 1] - c[i]) * h[i] / 3;
            }

            SaveResultsToFile();
        }

        // Сохранение коэффициентов в файл
        public void SaveResultsToFile() 
        {
            if (System.IO.File.Exists("The_spline_coefficients.txt"))
                System.IO.File.Delete("The_spline_coefficients.txt");

            string text = "В результате работы программы были получены следующие коэффициенты: \n";
            System.IO.File.AppendAllText("The_spline_coefficients.txt", text);

            for (int i = 1; i < countPoints; i++)
            {
                string coeff = "a[" + (i + 1).ToString() + "] = " + (Math.Round(a[i], 3)).ToString() + "\t\tb[" + (i + 1).ToString() + "] = " +
                (Math.Round(b[i], 3)).ToString() + " \t\tc[" + (i + 1).ToString() + "] = " + (Math.Round(c[i], 3)).ToString() +
                "\t\td[" + (i + 1).ToString() + "] = " + (Math.Round(d[i], 3)).ToString();
                System.IO.File.AppendAllText("The_spline_coefficients.txt", coeff + "\n");
            }
        }

    }
}
