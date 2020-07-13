#ifndef _IO_SOLE_H_
#define _IO_SOLE_H_

#include <random>
#include <ctime>
#include <iostream>
#include <vector>

using namespace std;

class IO
{
public:
	static vector<vector<double>> InputMatrix(const int);
	static vector<double> InputVector(const int);

    static vector<vector<double>> AutoGenMatrix(const int);
    static vector<double> AutoGenVector(const int);

	static void OutputMatrix(const vector<vector<double>>&, int);
	static void OutputVector(const vector<double>&, int);
};
//-----------------------------------------------------

vector<vector<double>> IO::InputMatrix(const int size)
{
    vector<vector<double>> matrix(size);

    cout << "\n������� ������� �������� " << size << " �� " << size <<" ��������(��).\n";
    cout << "������� �� �� ������, �������� ����� ������� Enter.\n";

    for (int i = 0; i < size; i++)
    {
        cout << "\n���� " << i + 1 << "-�� ������ �������...\n";

        vector<double> tmp(size);

        for (int j = 0; j < size; j++)
        {
            cout << "���� " << j + 1 << "-�� �������� � ���� ������: ";
            while (!(cin >> tmp[j]) || (cin.peek() != '\n'))
            {
                cin.clear();
                while (cin.get() != '\n');
                cout << "������������ ����, ��������� �������: ";
            }
        }

        matrix[i] = tmp;
    }

    return matrix;
}

vector<double> IO::InputVector(const int size)
{
    vector<double> input(size);
    cout << "\n������� " << size << " ��������(��) ������� ������ �����.\n";
    cout << "������� �� �� ������, �������� ����� ������� Enter.\n";
    for (int i = 0; i < size; i++) 
    {
        cout << "���� " << i + 1 << "-��: ";
        while (!(cin >> input[i]) || (cin.peek() != '\n'))
        {
            cin.clear();
            while (cin.get() != '\n');
            cout << "������������ ����, ��������� �������: ";
        }
    }

    return input;
}

vector<vector<double>> IO::AutoGenMatrix(const int size) 
{
    std::default_random_engine generator;
    generator.seed(static_cast<unsigned int>(time(0)));

    vector<vector<double>> matrix(size);

    for (int i = 0; i < size; i++)
    {
        vector<double> tmp(size);
        for (int j = 0; j < size; j++)
        {
            tmp[j] = generator() % 10;
        }
        matrix[i] = tmp;
    }

    for (int i = 0; i < size; i++)
    {
        for (int j = i; j < size; j++)
        {
            if (i == j)
                matrix[i][j] = matrix[i][j] + generator() % 100 + 100;
            matrix[i][j] = matrix[j][i];
        }
    }

    return matrix;
}

vector<double> IO::AutoGenVector(const int size)
{
    std::default_random_engine generator;
    generator.seed(static_cast<unsigned int>(time(0)));

    vector<double> tmp(size);
    for (int i = 0; i < size; i++)
    {
        tmp[i] = generator() % 100;
    }

    return tmp;
}

void IO::OutputMatrix(const vector<vector<double>>& matrix, int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << " ";
        for (int j = 0; j < size; j++)
        {
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }

}

void IO::OutputVector(const vector<double>& vector, int size)
{
    cout << "[";
    for (int i = 0; i < size - 1; i++)
        cout << vector[i] << ", ";
    cout << vector[size - 1] << "]";
    cout << endl;

    return;
};

#endif
