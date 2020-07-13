#include <windows.h>
#include <locale>
#include <iostream>
#include <vector>

#include "include/gauss.h"
#include "include/kramer.h"
#include "include/zeidel.h"
#include "include/simple_iterations.h"
#include "include/high_relaxation.h"
#include "include/LU_decomposition.h"
#include "include/gradient.h"
#include "include/io.h"

const int NotUsed = system("color F0");

double getAccur() {
    double accur = 0;

    do {
        std::cout << "������� ��������� �������� (�������� ������ ���� ������ 0, �������� 0.001): ";
        while (!(std::cin >> accur) || (std::cin.peek() != '\n'))
        {
            std::cin.clear();
            while (std::cin.get() != '\n');
            std::cout << "������������ ����, ��������� �������: ";
        }
        if (accur <= 0)
        {
            std::cout << "������� ������� ��������� ��������, ��������� �������.\n\n";
        }
    } while (accur <= 0);

    return accur;
}

void printMenu() {
    std::cout << "\n\n===================\n������� ����\n===================\n";
    std::cout << "1. ������ ���� ������\n"
        << "2. �������������� ���� ������\n"
        << "3. ������ �������\n"
        << "4. ���������������� �����\n"
        << "5. �����\n";
    std::cout << "\n������� ����� ������ ����: ";
}

void printMenuSolve() {
    std::cout << "\n\n===================\n���� �������\n===================\n";
    std::cout << "1. ����� ������\n"
        << "2. ����� �������\n"
        << "3. ����� ������� ��������\n"
        << "4. ����� �������\n"
        << "5. ����� ������� ����������\n"
        << "6. ����� LU-����������\n"
        << "7. ����� ����������� ����������\n"
        << "8. ����� \n";
    std::cout << "\n������� ����� ������ ����: ";
}

void useMenu() {
    int menuCase = 0;
    bool hasSystem = false;
    int dim = 0;

    std::vector<std::vector<double>> matrix;
    std::vector<double> b;
    std::vector<double> result;

    printMenu();
    while (menuCase != 5) {
        while (!(std::cin >> menuCase) || (std::cin.peek() != '\n'))
        {
            std::cin.clear();
            while (std::cin.get() != '\n');
            std::cout << "\n������������ ����, ��������� �������: ";
        }

        switch (menuCase)
        {
        case 1:
        {
            std::cout << "\n============\n������ ����...\n============" << std::endl;
            do {
                dim = 0;
                std::cout << "������� ����������� ������� (�� 2 �� 12): ";
                while (!(std::cin >> dim) || (std::cin.peek() != '\n'))
                {
                    std::cin.clear();
                    while (std::cin.get() != '\n');
                    std::cout << "������������ ����, ��������� �������: ";
                }
                if (dim < 2 || dim > 12) 
                {
                    std::cout << "������� ������� ����������� �������, ��������� �������.\n\n";
                }
            } while (dim < 2 || dim > 12);

            b = IO::InputVector(dim);
            std::cout << "\n������� ������ ������ ������ �����:\n";
            IO::OutputVector(b, dim);

            matrix = IO::InputMatrix(dim);
            std::cout << "\n������� ������� ������� �������������:\n";
            IO::OutputMatrix(matrix, dim);

            hasSystem = true;

            printMenu();
            break;
        }
        case 2:
        {
            std::cout << "\n============\n�������������� ����...\n============" << std::endl;
            do {
                dim = 0;
                std::cout << "������� ����������� ������� (�� 2 �� 12): ";
                while (!(std::cin >> dim) || (std::cin.peek() != '\n'))
                {
                    std::cin.clear();
                    while (std::cin.get() != '\n');
                    std::cout << "������������ ����, ��������� �������: ";
                }
                if (dim < 2 || dim > 12)
                {
                    std::cout << "������� ������� ����������� �������, ��������� �������.\n\n";
                }
            } while (dim < 2 || dim > 12);

            b = IO::AutoGenVector(dim);
            std::cout << "\n������� ������������ ������ ������ �����:\n";
            IO::OutputVector(b, dim);

            matrix = IO::AutoGenMatrix(dim);
            std::cout << "\n������� ������������� ������� �������������:\n";
            IO::OutputMatrix(matrix, dim);

            hasSystem = true;

            printMenu();
            break;
        }
        case 3:
        {
            if (!hasSystem)
            {
                std::cout << "\n�� ������� ������� �������� ���������! �������� ��������" << std::endl;
                printMenu();
                break;
            }

            int solveMenu = 0;
            printMenuSolve();
            while (solveMenu != 8) {
                while (!(std::cin >> solveMenu) || (std::cin.peek() != '\n'))
                {
                    std::cin.clear();
                    while (std::cin.get() != '\n');
                    std::cout << "\n������������ ����, ��������� �������: ";
                }

                switch (solveMenu)
                {
                case 1:
                {
                    result = Gauss::Solve(matrix, b, dim);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 2:
                {
                    result = Kramer::Solve(matrix, b, dim);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 3:
                {
                    double accur = getAccur();
                    result = Simple_Iterations::Solve(matrix, b, dim, accur);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 4:
                {
                    double accur = getAccur();
                    result = Zeidel::Solve(matrix, b, dim, accur);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 5:
                {
                    double accur = getAccur();
                    result = High_Relaxation::Solve(matrix, b, dim, accur, 1.5);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 6:
                {
                    result = LU_Decomposition::Solve(matrix, b, dim);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 7:
                {
                    double accur = getAccur();
                    result = Gradient::Solve(matrix, b, dim, accur);
                    IO::OutputVector(result, dim);
                    printMenuSolve();
                    break;
                }
                case 8:
                {
                    std::cout << "\n�������... ";
                    break;
                }
                default:
                {
                    std::cout << "\n������ ������ ���� �� ����������. �������� ��������. ";
                    printMenuSolve();
                    break;
                }
                }
            }
            printMenu();
            break;
        }
        case 4:
        {
            //vector<double> m1 = { 2, 3, -1 };
            //vector<double> m2 = { 1, -1, 6 };
            //vector<double> m3 = { 6, -2, 1 };
            //matrix = { m1, m2, m3 };
            //b = { 7, 14, 11 };
            std::cout << "\n============\n���������������� �����...\n============" << std::endl;
            
            int sizetest = 12;

            vector<double> b = IO::AutoGenVector(sizetest);
            std::cout << "\n������� ������������ ������ ������ �����:\n";
            IO::OutputVector(b, sizetest);

            vector<vector<double>> matrix = IO::AutoGenMatrix(sizetest);
            std::cout << "\n������� ������������� ������� �������������:\n";
            IO::OutputMatrix(matrix, sizetest);


            result = Gauss::Solve(matrix, b, sizetest);
            IO::OutputVector(result, sizetest);

            result = Kramer::Solve(matrix, b, sizetest);
            IO::OutputVector(result, sizetest);

			result = Simple_Iterations::Solve(matrix, b, sizetest, 0.0001);
			IO::OutputVector(result, sizetest);

			result = Zeidel::Solve(matrix, b, sizetest, 0.0001);
			IO::OutputVector(result, sizetest);

            result = High_Relaxation::Solve(matrix, b, sizetest, 0.0001, 1.5);
            IO::OutputVector(result, sizetest);

            result = LU_Decomposition::Solve(matrix, b, sizetest);
            IO::OutputVector(result, sizetest);

            result = Gradient::Solve(matrix, b, sizetest, 0.0001);
            IO::OutputVector(result, sizetest);

            printMenu();
            break;
        }
        case 5:
        {
            std::cout << "\n�������..." << std::endl;
            break;
        }
        default:
        {
            std::cout << "\n������ ������ ���� �� ����������. �������� ��������. ";
            printMenu();
            break;
        }
        }
    }
}


void main()
{
    setlocale(LC_ALL, "Russian");
    std::cout << "������������ ������ � 2 ������� ������ �������� ��������� ���������� ��������\n" <<
        "������� ��������� �������, ������ 381706-1";
    useMenu();
    std::cout << "\n��������� ������� ���������!" << std::endl;
    return;
}