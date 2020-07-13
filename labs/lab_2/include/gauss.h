#ifndef _GAUSS_H_
#define _GAUSS_H_

#include <vector>
#include <iostream>
#include <chrono>
#include "io.h"

using namespace std;

class Gauss
{
private:
    static void CastToStandart(vector<vector<double>>&, vector<double>&, int, int, int);
	static vector<vector<double>> Forward(vector<vector<double>>&, vector<double>&, int);
	static vector<double> Backward(vector<vector<double>>&, vector<double>&, int);
public:
	static vector<double> Solve(const vector<vector<double>>&, const vector<double>&, int);
};
//--------------------------------------------------------------

void Gauss::CastToStandart(vector<vector<double>>& matrix, vector<double>& b, int size, int row, int col)
{
	double max = matrix[row][col];
	int maxRow = row;

	for (int i = row + 1; i < size; i++)
		if (max < matrix[i][col])
		{
			max = matrix[i][col];
			maxRow = i;
		}

	for (int i = col; i < size; i++)
		swap(matrix[maxRow][i], matrix[row][i]);

	swap(b[maxRow], b[row]);
};

vector<vector<double>> Gauss::Forward(vector<vector<double>>& matrix, vector<double>& b, int size)
{
	int i = 0, j = 0, k;
	double c;

	//cout << "Запущен прямой ход метода Гаусса..." << endl;

	for (int i = 0; i < size; i++)  // по строкам
	{
		if (i < (size - 1))
			CastToStandart(matrix, b, size, i, i);
		
        if (fabs(matrix[i][i]) < 1E-14) 
        {
            throw string("Система не может быть решена методом Гаусса.\nВозвращен пустой вектор-результат.");
        }
		b[i] /= matrix[i][i];
		for (int j = size - 1; j >= i; j--)  // нормировка в строке
			matrix[i][j] /= matrix[i][i];
		
		for (int j = i + 1; j < size; j++)
		{
			double coeff = matrix[j][i] / matrix[i][i];

			for (int k = i; k < size; k++)
				matrix[j][k] -= coeff * matrix[i][k];

			b[j] -= coeff * b[i];
		}
	}
	//cout << "Готово!" << endl << endl;
	
	return matrix;
};

vector<double> Gauss::Backward(vector<vector<double>>& matrix, vector<double>& b, int size)
{
	vector<double> x(size);

	//cout << "Запущен обратный ход метода Гаусса..." << endl;

	for (int i = size - 1; i >= 0; i--)
	{
		x[i] = b[i];

		for (int j = i + 1; j < size; j++)
			x[i] = x[i] - matrix[i][j] * x[j];
	}

    //cout << "Готово!" << endl << endl;

	return x;
};

vector<double> Gauss::Solve(const vector<vector<double>>& matrix, const vector<double>& b, int size)
{
    cout << "\n=========\nРешение методом Гаусса..." << endl << endl;
    auto T1 = std::chrono::steady_clock::now();

    vector<double> x(size);
    vector<vector<double>> tempMatrix(matrix);
    vector<double> tempVector(b);

    try
    {
        tempMatrix = Forward(tempMatrix, tempVector, size);
        x = Backward(tempMatrix, tempVector, size);
    }
    catch (string str) 
    {
        cout << str << endl;
        return x;
    }
    auto T2 = std::chrono::steady_clock::now();
    auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1);

    cout << "Система решена! Время выполнения: " << time.count() << " microsec" << endl << endl;

	return x;
};

#endif