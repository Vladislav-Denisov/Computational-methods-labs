#ifndef _ZEIDEL_H_
#define _ZEIDEL_H_

#include "utils.h"
#include <vector>
#include <iostream>
#include <chrono>

using namespace std;

class Zeidel
{
private:
	static double MatrixNorm(vector<vector<double> >&, int);
	static void MainDiagonalElements(vector<vector<double> >&, vector<double>&, int);
	static void NormalizationDiagonalElements(vector<vector<double> >&, vector<double>&, int);
public:
    static vector<double> Solve(const vector<vector<double> >&, const vector<double>&, int, double);
};
//-------------------------------------------------------------

double Zeidel::MatrixNorm(vector<vector<double> >& matrix, int size)
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

void Zeidel::MainDiagonalElements(vector<vector<double> >& matrix, vector<double>& b, int size)
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

void Zeidel::NormalizationDiagonalElements(vector<vector<double> >& matrix, vector<double>& b, int size)
{
	for (int i = 0; i < size; i++)
	{
		double norm = matrix[i][i];

		if (abs(norm) < 1E-14)
		{
			cout << "������� �������." << endl;
			return;
		}

		for (int j = 0; j < size; j++)
			matrix[i][j] = matrix[i][j] / norm;

		b[i] /= norm;
		matrix[i][i] = 0;
	}
};

vector<double> Zeidel::Solve(const vector<vector<double> >& _matrix, const vector<double>& _b, int size, double accuracy)
{
    cout << "\n=========\n������� ������� �������..." << endl << endl;
    auto T1 = std::chrono::steady_clock::now();

	vector<vector<double>> matrix(_matrix);
	vector<double> b(_b);
	vector<double> x(size);

	double normX = 100;
	double detMatrix = Determinant(matrix);

	if (detMatrix == 0)
	{
		cout << "������� �� ����� �������, ������� ������������ ����� 0." << endl;
		cout << "��������� ������ ������-���������." << endl;
		return x;
	}

	MainDiagonalElements(matrix, b, size);
	NormalizationDiagonalElements(matrix, b, size);

	double normMatrix = MatrixNorm(matrix, size);

    auto timedif1 = std::chrono::steady_clock::now();
	if (normMatrix >= 1)
	{
		int check;

		cout << "�� ����������� ����������� ������� ���������� ������ ������� ��������, �.�. ����� ������� " <<
			normMatrix << " >= 1." << endl;
		cout << "������� 1, ����� �������� ����� ������� (�� �������������), 0, ����� �����." << endl;

		cin >> check;
		if (check != 1)
		{
			cout << "��������� ������-������ ���������." << endl;
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

			x[i] = xNext[i];
		}

		count++;
	} while ((normX > accuracy) && (count < maxIters));

    auto T2 = std::chrono::steady_clock::now();
    auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1 - timedif);

    cout << "������� ������ �� " << count << " ��������! ����� ����������: " << time.count() << " microsec" << endl << endl;

    return x;
}

#endif
