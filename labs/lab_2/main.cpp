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
        std::cout << "Введите требуемую точность (значение должно быть больше 0, например 0.001): ";
        while (!(std::cin >> accur) || (std::cin.peek() != '\n'))
        {
            std::cin.clear();
            while (std::cin.get() != '\n');
            std::cout << "Некорректный ввод, повторите попытку: ";
        }
        if (accur <= 0)
        {
            std::cout << "Неверно указана требуемая точность, повторите попытку.\n\n";
        }
    } while (accur <= 0);

    return accur;
}

void printMenu() {
    std::cout << "\n\n===================\nГлавное меню\n===================\n";
    std::cout << "1. Ручной ввод данных\n"
        << "2. Автоматический ввод данных\n"
        << "3. Решить систему\n"
        << "4. Демонстрационный режим\n"
        << "5. Выход\n";
    std::cout << "\nВведите номер пункта меню: ";
}

void printMenuSolve() {
    std::cout << "\n\n===================\nМеню решения\n===================\n";
    std::cout << "1. Метод Гаусса\n"
        << "2. Метод Крамера\n"
        << "3. Метод простых итераций\n"
        << "4. Метод Зейделя\n"
        << "5. Метод верхней релаксации\n"
        << "6. Метод LU-разложения\n"
        << "7. Метод сопряженных градиентов\n"
        << "8. Выход \n";
    std::cout << "\nВведите номер пункта меню: ";
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
            std::cout << "\nНекорректный ввод, повторите попытку: ";
        }

        switch (menuCase)
        {
        case 1:
        {
            std::cout << "\n============\nРучной ввод...\n============" << std::endl;
            do {
                dim = 0;
                std::cout << "Введите размерность системы (от 2 до 12): ";
                while (!(std::cin >> dim) || (std::cin.peek() != '\n'))
                {
                    std::cin.clear();
                    while (std::cin.get() != '\n');
                    std::cout << "Некорректный ввод, повторите попытку: ";
                }
                if (dim < 2 || dim > 12) 
                {
                    std::cout << "Неверно указана размерность системы, повторите попытку.\n\n";
                }
            } while (dim < 2 || dim > 12);

            b = IO::InputVector(dim);
            std::cout << "\nУспешно введен вектор правой части:\n";
            IO::OutputVector(b, dim);

            matrix = IO::InputMatrix(dim);
            std::cout << "\nУспешно введена матрица коэффициентов:\n";
            IO::OutputMatrix(matrix, dim);

            hasSystem = true;

            printMenu();
            break;
        }
        case 2:
        {
            std::cout << "\n============\nАвтоматический ввод...\n============" << std::endl;
            do {
                dim = 0;
                std::cout << "Введите размерность системы (от 2 до 12): ";
                while (!(std::cin >> dim) || (std::cin.peek() != '\n'))
                {
                    std::cin.clear();
                    while (std::cin.get() != '\n');
                    std::cout << "Некорректный ввод, повторите попытку: ";
                }
                if (dim < 2 || dim > 12)
                {
                    std::cout << "Неверно указана размерность системы, повторите попытку.\n\n";
                }
            } while (dim < 2 || dim > 12);

            b = IO::AutoGenVector(dim);
            std::cout << "\nУспешно сгенерирован вектор правой части:\n";
            IO::OutputVector(b, dim);

            matrix = IO::AutoGenMatrix(dim);
            std::cout << "\nУспешно сгенерирована матрица коэффициентов:\n";
            IO::OutputMatrix(matrix, dim);

            hasSystem = true;

            printMenu();
            break;
        }
        case 3:
        {
            if (!hasSystem)
            {
                std::cout << "\nНе введена система линейных уравнений! Действие отменено" << std::endl;
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
                    std::cout << "\nНекорректный ввод, повторите попытку: ";
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
                    std::cout << "\nВыходим... ";
                    break;
                }
                default:
                {
                    std::cout << "\nТакого пункта меню не существует. Действие отменено. ";
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
            std::cout << "\n============\nДемонстрационный режим...\n============" << std::endl;
            
            int sizetest = 12;

            vector<double> b = IO::AutoGenVector(sizetest);
            std::cout << "\nУспешно сгенерирован вектор правой части:\n";
            IO::OutputVector(b, sizetest);

            vector<vector<double>> matrix = IO::AutoGenMatrix(sizetest);
            std::cout << "\nУспешно сгенерирована матрица коэффициентов:\n";
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
            std::cout << "\nВыходим..." << std::endl;
            break;
        }
        default:
        {
            std::cout << "\nТакого пункта меню не существует. Действие отменено. ";
            printMenu();
            break;
        }
        }
    }
}


void main()
{
    setlocale(LC_ALL, "Russian");
    std::cout << "Лабораторная работа № 2 Решение систем линейных уравнений различными методами\n" <<
        "Денисов Владислав Львович, группа 381706-1";
    useMenu();
    std::cout << "\nПрограмма успешно завершена!" << std::endl;
    return;
}