#ifndef _UTILS_H_
#define _UTILS_H_

#include <vector>

using namespace std;

double CalcEvklNorm(const vector<double>&);

bool isConvergenceZeidel(const vector<vector<double>>&);

double Determinant(const vector<vector<double>>&);

double vectorMult(const vector<double>&, const vector<double>&);
vector<double> matrixVectorMult(const vector<vector<double>>&, const vector<double>&);

#endif