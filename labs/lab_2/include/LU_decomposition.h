#ifndef _LU_DECOMPOSITION_H_
#define _LU_DECOMPOSITION_H_

#include "utils.h"
#include <vector>
#include <iostream>
#include <chrono>

using namespace std;

class LU_Decomposition
{
private:
    static void LUDecompose(const vector<vector<double> >&, vector<vector<double> >&, vector<vector<double> >&);
public:
    static vector<double> Solve(const vector<vector<double> >&, const vector<double>&, int);
};
//----------------------------------------------------------

void LU_Decomposition::LUDecompose(const vector<vector<double> >& matrix, vector<vector<double> >& L, vector<vector<double> >& U) 
{
    for (int j = 0; j < matrix.size(); j++)
    {
        U[0][j] = matrix[0][j];
        L[j][0] = matrix[j][0] / U[0][0];
    }

    for (int i = 1; i < matrix.size(); i++)
    {
        for (int j = i; j < matrix.size(); j++)
        {
            double sum = 0.0;
            for (int k = 0; k < i; k++)
            {
                sum += L[i][k] * U[k][j];
            }

            U[i][j] = matrix[i][j] - sum;
        }

        for (int j = i; j < matrix.size(); j++)
        {
            double sum = 0.0;
            for (int k = 0; k < i; k++)
            {
                sum += L[j][k] * U[k][i];
            }

            L[j][i] = (matrix[j][i] - sum) / U[i][i];
        }
    }

    return;
}

vector<double> LU_Decomposition::Solve(const vector<vector<double> >& _matrix, const vector<double>& _b, int size) 
{
    cout << "\n=========\nРешение методом LU-разложения..." << endl << endl;

    vector<vector<double> > checkMatrix(_matrix);
    for (int i = 0; i < size; i++) 
    {
        double detMatrix = Determinant(checkMatrix);
        if (detMatrix == 0)
        {
            vector<double> result(_matrix.size());
            cout << "Система не может быть решена этим методом, один из угловых миноров равен 0." << endl;
            cout << "Возвращен пустой вектор-результат." << endl;
            return result;
        }
        for (int j = 0; j < checkMatrix[0].size(); j++)
        {
            checkMatrix[j].pop_back();
        }
        checkMatrix.pop_back();
        
    }

    auto T1 = std::chrono::steady_clock::now();

    vector<double> x(size);
    vector<double> y(size);

    vector<vector<double> > L(_matrix), U(_matrix);
    for (int i = 0; i < _matrix.size(); i++)
    {
        for (int j = 0; j < _matrix.size(); j++)
        {
            L[i][j] = U[i][j] = 0;
        }
    }
    
    if (fabs(_matrix[0][0]) < 1E-14)
    {
        cout << "Система не может быть решена методом LU-разложения." << endl;
        cout << "т.к. элемент a[0][0] равен 0." << endl;
        cout << "Возвращен пустой-вектор результат." << endl;
        return x;
    }

    LUDecompose(_matrix, L, U);

    for (int i = 0; i < _matrix.size(); i++)
    {
        double sum = 0.0;
        for (int j = 0; j < i; j++)
        {
            sum += L[i][j] * y[j];
        }

        y[i] = _b[i] - sum;
    }

    for (int i = _matrix.size() - 1; i >= 0; i--)
    {
        double sum = 0.0;
        for (int j = i + 1; j < _matrix.size(); j++)
        {
            sum += U[i][j] * x[j];
        }

        x[i] = (y[i] - sum) / U[i][i];
    }

    auto T2 = std::chrono::steady_clock::now();
    auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1);

    cout << "Система решена! Время выполнения: " << time.count() << " microsec" << endl << endl;

    return x;
}

#endif
