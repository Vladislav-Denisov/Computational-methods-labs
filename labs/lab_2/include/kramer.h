#ifndef _KRAMER_H_
#define _KRAMER_H_

#include "utils.h"
#include <vector>
#include <iostream>
#include <chrono>

using namespace std;

class Kramer
{
public:
    static vector<double> Solve(const vector<vector<double>>&, const vector<double>&, int);
};

vector<double> Kramer::Solve(const vector<vector<double>>& matrix, const vector<double>& b, int size)
{
    cout << "\n=========\n������� ������� �������..." << endl << endl;
    auto T1 = std::chrono::steady_clock::now();

    vector<double> x;
    vector<double> dets;

    double detMatrix = Determinant(matrix);
    if (detMatrix != 0)
    {
        // ���������� ������������� ������ � ����� ���������� �������� �� ������� ��������� ������.
        for (int i = 0; i < size; i++)
        {
            vector<vector<double>> tempMatrix(matrix);
            for (int j = 0; j < tempMatrix.size(); j++)
            {
                tempMatrix[j][i] = b[j];
            }

            dets.push_back(Determinant(tempMatrix));
        }

        // ���������� ������
        for (double d : dets) {
            x.push_back(d / detMatrix);
        }

        auto T2 = std::chrono::steady_clock::now();
        auto time = std::chrono::duration_cast<std::chrono::microseconds>(T2 - T1);

        cout << "������� ������! ����� ����������: " << time.count() << " microsec" << endl << endl;

        return x;
    }
    else 
    {
        vector<double> x(size);
        cout << "������� �� ����� �������, ������� ������������ ����� 0." << endl;
        cout << "��������� ������ ������-���������." << endl;
        return x;
    }
}

#endif
