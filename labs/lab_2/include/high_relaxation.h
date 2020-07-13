#ifndef _HIGH_RELAXATION_H_
#define _HIGH_RELAXATION_H_

#include "utils.h"
#include <vector>
#include <iostream>
#include <chrono>

using namespace std;

class High_Relaxation
{
private:
	static double MatrixNorm(vector<vector<double> >&, int);
	static void MainDiagonalElements(vector<vector<double> >&, vector<double>&, int);
	static void NormalizationDiagonalElements(vector<vector<double> >&, vector<double>&, int);
public:
	static vector<double> Solve(vector<vector<double> >&, vector<double>&, int, double, double);
};
//----------------------------------------------------------

double High_Relaxation::MatrixNorm(vector<vector<double> >& matrix, int size)
{
	double max = 0;

	for (int i = 0; i < size; i++)
	{
		double sum = 0;

		for (int j = 0; j < size; j++)
			sum += abs(matrix[i][j]);

		if (sum > max)
			max = sum;
	}

	return max;
};

void High_Relaxation::MainDiagonalElements(vector<vector<double> >& matrix, vector<double>& b, int size)
{
	for (int i = 0; i < size; i++)
	{
		double max = matrix[i][i];
		int maxIndex = i;

		for (int j = i; j < size; j++)
		{
			if (matrix[j][i] > max)
			{
				max = matrix[j][i];
				maxIndex = j;
			}
		}

		if (maxIndex != i)
		{
			for (int j = 0; j < size; j++)
				swap(matrix[i][j], matrix[maxIndex][j]);
			swap(b[i], b[maxIndex]);
		}
	}
};

void High_Relaxation::NormalizationDiagonalElements(vector<vector<double> >& matrix, vector<double>& b, int size)
{
	for (int i = 0; i < size; i++)
	{
		double norm = matrix[i][i];

		if (abs(norm) < 1E-14)
		{
			cout << "Нулевой элемент." << endl;
			return;
		}

		for (int j = 0; j < size; j++)
			matrix[i][j] = matrix[i][j] / norm;

		b[i] /= norm;
		matrix[i][i] = 0;
	}
};

vector<double> High_Relaxation::Solve(vector<vector<double> >& _matrix, vector<double>& _b, 
	int size, double accuracy, double omega)
{
	cout << "\n=========\nРешение методом верхней релаксации..." << endl << endl;

    while ((omega <= 1) || (omega >= 2))
    {
        cout << "Текущий коэффициент omega " << omega << " не принадлежит интервалу (1;2)." << endl;
        cout << "Повторите ввод: ";
        cin >> omega;
        cout << endl;
    }

    auto T1 = std::chrono::steady_clock::now();

	vector<vector<double>> matrix(_matrix);
	vector<double> b(_b);
	vector<double> x(size);

	double normX = 100;
	double detMatrix = Determinant(matrix);

	if (detMatrix == 0)
	{
		cout << "Система не имеет решения, главный определитель равен 0." << endl;
		cout << "Возвращен пустой-вектор результат." << endl;
		return x;
	}

	MainDiagonalElements(matrix, b, size);
	NormalizationDiagonalElements(matrix, b, size);

	double normMatrix = MatrixNorm(matrix, size);

    auto timedif1 = std::chrono::steady_clock::now();
	if (normMatrix >= 1)
	{
		int check;

		cout << "Не выполняется достаточное условие сходимости метода верхней релаксации, т.к. норма матрицы " <<
			normMatrix << " >= 1." << endl;
		cout << "Введите 1, чтобы попыться найти решение (не гарантируется), 0, чтобы выйти." << endl;

		cin >> check;
		if (check != 1)
		{
			cout << "Возвращен пустой-вектор результат." << endl;
			return x;
		}
	}
    auto timedif2 = std::chrono::steady_clock::now();
    auto timedif = std::chrono::duration_cast<std::chrono::microseconds>(timedif2 - timedif1);

	int maxIters = 10000;
	int count = 0;

	vector<double> xNext(b);
	x = b;

	do {
		x = xNext;
		xNext = b;
		normX = 0;

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
				xNext[i] -= matrix[i][j] * x[j];

			if (abs(xNext[i] - x[i]))
				normX = abs(xNext[i] - x[i]);

			xNext[i] = (1 - omega) * x[i] + xNext[i] * omega;
			x[i] = xNext[i];
		}

		count++;
	} while ((normX > accuracy) && (count < maxIters));

    auto T2 = std::chrono::steady_clock::now();
    auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1 - timedif);

    cout << "Система решена за "<< count <<" итераций! Время выполнения: " << time.count() << " microsec" << endl << endl;

	return x;

};

#endif
