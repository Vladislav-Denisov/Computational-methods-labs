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

    cout << "\n¬ведите матрицу размером " << size << " на " << size <<" элемента(ов).\n";
    cout << "¬водите их по одному, раздел€€ путем нажати€ Enter.\n";

    for (int i = 0; i < size; i++)
    {
        cout << "\n¬вод " << i + 1 << "-ой строки матрицы...\n";

        vector<double> tmp(size);

        for (int j = 0; j < size; j++)
        {
            cout << "¬вод " << j + 1 << "-го элемента в этой строке: ";
            while (!(cin >> tmp[j]) || (cin.peek() != '\n'))
            {
                cin.clear();
                while (cin.get() != '\n');
                cout << "Ќекорректный ввод, повторите попытку: ";
            }
        }

        matrix[i] = tmp;
    }

    return matrix;
}

vector<double> IO::InputVector(const int size)
{
    vector<double> input(size);
    cout << "\n¬ведите " << size << " элемента(ов) вектора правой части.\n";
    cout << "¬водите их по одному, раздел€€ путем нажати€ Enter.\n";
    for (int i = 0; i < size; i++) 
    {
        cout << "¬вод " << i + 1 << "-го: ";
        while (!(cin >> input[i]) || (cin.peek() != '\n'))
        {
            cin.clear();
            while (cin.get() != '\n');
            cout << "Ќекорректный ввод, повторите попытку: ";
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
