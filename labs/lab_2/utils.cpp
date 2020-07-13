#include "include/utils.h"
#include <iostream>

//-----------------------------------------------------------
double CalcEvklNorm(const vector<double>& x)
{
    double norm = 0.0;

    for (size_t i = 0; i != x.size(); ++i) {
        norm += x[i] * x[i];
    }

    return sqrt(norm);
}

//-----------------------------------------------------------
bool isConvergenceZeidel(const vector<vector<double>>& matrix)
{
    double sum = 0.0;
    for (std::vector<double> v: matrix) {
        for (double val : v) {
            sum += pow(val, 2);
        }
    }
    double eNorm = sqrt(sum);
    return (eNorm < 1);
}

//-----------------------------------------------------------
void CastToStandartForDet(vector<vector<double>>& matrix, int row, int col, bool& isChange)
{
    double max = matrix[row][col];
    int maxRow = row;
    isChange = false;

    for (int i = row + 1; i < matrix.size(); i++)
        if (max < matrix[i][col])
        {
            max = matrix[i][col];
            maxRow = i;
        }

    if (row != maxRow)
    {
        for (int i = col; i < matrix.size(); i++)
            swap(matrix[maxRow][i], matrix[row][i]);
        isChange = true;
    }
}

double Determinant(const vector<vector<double>>& matrix) {
    int count = 0;
    bool isChange;

    vector<vector<double>> temp(matrix);
    for (int i = 0; i < temp.size(); i++)
    {
        if (i < (temp.size() - 1)) {
            CastToStandartForDet(temp, i, i, isChange);
            if (isChange) 
            {
                count++;
            }
        }

        // Если на диагонали встретился 0, то определитель станет равен 0.
        if (fabs(temp[i][i]) < 1E-14) 
            return 0;

        for (int j = i + 1; j < temp.size(); j++)
        {
            double coeff = temp[j][i] / temp[i][i];

            for (int k = i; k < temp.size(); k++)
                temp[j][k] -= coeff * temp[i][k];
        }
    }

    // Вычисляем непосредственно определитель
    double det = 1.0;
    for (int i = 0; i < temp.size(); i++) 
    {
        det *= temp[i][i];
    }

    if (count % 2 == 1)
        det = -det;  // меняем знак, если количество перестановок нечетно

    return det;
}

double vectorMult(const std::vector<double>& vectorA, const std::vector<double>& vectorB)
{
    double res = 0.0;

    for (size_t i = 0; i < vectorA.size(); ++i)
        res += vectorA[i] * vectorB[i];

    return res;
}

vector<double> matrixVectorMult(const vector<vector<double>>& matrix, const vector<double>& vector)
{
    std::vector<double> res(vector.size());

    for (size_t i = 0; i < vector.size(); ++i) {
        res[i] = 0.0;
        for (size_t j = 0; j < vector.size(); ++j) {
            res[i] += matrix[i][j] * vector[j];
        }
    }

    return res;
}
