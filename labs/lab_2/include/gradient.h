#ifndef _GRADIENT_H_
#define _GRADIENT_H_

#include "utils.h"
#include <vector>
#include <iostream>
#include <chrono>

using namespace std;

class Gradient
{
public:
    static vector<double> Solve(const vector<vector<double>>&, const vector<double>&, int, double);
};

vector<double> Gradient::Solve(const vector<vector<double>>& matrix, const vector<double>& vector, int size, double accuracy)
{
    cout << "\n=========\nРешение методом Сопряженных градиентов..." << endl << endl;
    std::vector<double> result(size);

    double detMatrix = Determinant(matrix);
    if (detMatrix == 0)
    {
        cout << "Система не имеет решения, главный определитель равен 0." << endl;
        cout << "Возвращен пустой вектор-результат." << endl;
        return result;
    }
    
    auto T1 = std::chrono::steady_clock::now();

    int iters = 0;
    double beta = 0.0, alpha = 0.0, check = 0.0;

    for (int i = 0; i < size; i++) {
        result[i] = 1;
    }

    std::vector<double> Ah = matrixVectorMult(matrix, result);
    std::vector<double> rprev(size), rnext(size);
    for (int i = 0; i < size; i++)
        rprev[i] = vector[i] - Ah[i];

    std::vector<double> h(rprev);

    do {
        iters++;
        Ah = matrixVectorMult(matrix, h);
        alpha = vectorMult(rprev, rprev) / vectorMult(h, Ah);
        for (int i = 0; i < size; i++) {
            result[i] += alpha * h[i];
            rnext[i] = rprev[i] - alpha * Ah[i];
        }
        beta = vectorMult(rnext, rnext) / vectorMult(rprev, rprev);

        for (int j = 0; j < size; j++)
            h[j] = rnext[j] + beta * h[j];

        rprev = rnext;
    } while ((CalcEvklNorm(rnext) > accuracy) && (iters <= size));

    auto T2 = std::chrono::steady_clock::now();
    auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1);

    cout << "Система решена за " << iters << " итераций! Время выполнения: " << time.count() << " microsec" << endl << endl;

    return result;
}

#endif
